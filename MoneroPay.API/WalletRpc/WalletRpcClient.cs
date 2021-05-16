using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mime;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MoneroPay.API.Models.Monero;
using System.IO;
using System.Net;

namespace MoneroPay.API.WalletRpc
{
    public class WalletRpcClient : IWalletRpcClient
    {
        private readonly ILogger<WalletRpcClient> _logger;
        private readonly string _rpcUri;
        private readonly Func<IEnumerable<string>> _getInformationLogs;
        private readonly Func<IEnumerable<string>> _getWarningLogs;
        private readonly Func<IEnumerable<string>> _getDebugLogs;
        private readonly Func<IEnumerable<string>> _getErrorLogs;
        private readonly string _rpcLogin;
        private readonly string _rpcUsername;
        private readonly string _rpcPassword;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        private readonly Lazy<Task<bool>> _rpcServerReady;
        public string JsonRpcUri => _rpcUri;
        public IEnumerable<string> InformationLogs => _getInformationLogs();
        public IEnumerable<string> WarningLogs => _getWarningLogs();
        public IEnumerable<string> DebugLogs => _getDebugLogs();
        public IEnumerable<string> ErrorLogs => _getErrorLogs();

        internal WalletRpcClient(
                ILogger<WalletRpcClient> logger,
                string rpcUri,
                string rpcLogin,
                Func<IEnumerable<string>> getInformationLogs,
                Func<IEnumerable<string>> getWarningLogs,
                Func<IEnumerable<string>> getDebugLogs,
                Func<IEnumerable<string>> getErrorLogs)
        {
            _logger = logger;
            _rpcUri = rpcUri;
            _getInformationLogs = getInformationLogs;
            _getWarningLogs = getWarningLogs;
            _getDebugLogs = getDebugLogs;
            _getErrorLogs = getErrorLogs;
            _rpcLogin = rpcLogin;
            var usernameAndMaybePassword = _rpcLogin.Split(":", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (usernameAndMaybePassword.Length > 2) throw new ArgumentException(nameof(rpcLogin), $"Splitting the login on ':' should result in either 1 or 2 entries (u, u:p) but {usernameAndMaybePassword.Length} entries were returned");
            _rpcUsername = usernameAndMaybePassword[0];
            _rpcPassword = usernameAndMaybePassword.Length == 2 ? usernameAndMaybePassword[1] : string.Empty;

            _rpcServerReady = new Lazy<Task<bool>>(async () => await IsRpcServerHealthy(TimeSpan.FromMinutes(1)));
        }
        
        private async Task<string> JsonRpcAsTextAsync(string method, object parameters, string? id = null, bool waitForHealthCheck = true, CancellationToken cancellationToken = default)
        {
            if (waitForHealthCheck) await _rpcServerReady.Value;
            var request = new MoneroRpcRequest<object>(method: method, parameters: parameters, id: id);
            var requestContent = new StringContent(
                JsonSerializer.Serialize(request, _jsonSerializerOptions),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var credentials = new CredentialCache { { new Uri(_rpcUri), "Digest", new NetworkCredential(_rpcUsername, _rpcPassword) } };
            var httpClientHandler = new HttpClientHandler
            {
                PreAuthenticate = false,
                Credentials = credentials
            };
            using var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_rpcLogin)));
            using var httpResponse = await httpClient.PostAsync(_rpcUri, requestContent, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return await httpResponse.Content.ReadAsStringAsync();
        }


        public async Task<IMoneroRpcResponse<TResult>?> JsonRpcAsync<TParameters, TResult>(
                string method,
                TParameters parameters,
                string? id = default,
                CancellationToken cancellationToken = default)
            where TResult : class
            where TParameters : class
        {
            var responseString = await JsonRpcAsTextAsync(method, parameters, id, waitForHealthCheck: true, cancellationToken);
            return JsonSerializer.Deserialize<MoneroRpcResponse<TResult>>(responseString);
        }

        public Task<string> JsonRpcAsTextAsync(string method, object parameters, string? id = null, CancellationToken cancellationToken = default)
        {
            return JsonRpcAsTextAsync(method, parameters, id, waitForHealthCheck: true, cancellationToken);
        }

        private async Task<bool> IsRpcServerHealthy(TimeSpan timeout)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < timeout)
            {
                try
                {
                    await JsonRpcAsTextAsync(
                        method: "get_address",
                        parameters: new GetAddressRpcParameters(0),
                        waitForHealthCheck: false
                    );
                    return true;
                }
                catch (HttpRequestException error)
                {
                    _logger.LogWarning(error.Message);
                }
            }
            return false;
        }
    }
}