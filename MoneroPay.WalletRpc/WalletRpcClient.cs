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
using System.Net;
using Microsoft.Extensions.Logging;
using MoneroPay.WalletRpc.Models;

namespace MoneroPay.WalletRpc
{
    public class WalletRpcClient : IWalletRpcClient, IAsyncDisposable
    {
        private readonly ILogger<WalletRpcClient> _logger;
        private readonly string _rpcUri;
        private readonly string? _rpcLogin;
        private readonly string? _rpcUsername;
        private readonly string? _rpcPassword;
        private readonly bool _acceptSelfSignedSslCerts;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web);
        private readonly Lazy<Task<bool>> _rpcServerReady;
        private bool _disposed;
        public string JsonRpcUri => _rpcUri;

        internal WalletRpcClient(
                ILogger<WalletRpcClient> logger,
                string rpcUri,
                string? rpcLogin = null,
                bool acceptSelfSignedSllCerts = true)
        {
            _logger = logger;
            _rpcUri = rpcUri;
            _acceptSelfSignedSslCerts = acceptSelfSignedSllCerts;
            
            _rpcLogin = rpcLogin;
            if (!string.IsNullOrWhiteSpace(_rpcLogin))
            {
                var usernameAndMaybePassword = _rpcLogin.Split(":", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (usernameAndMaybePassword.Length > 2) throw new ArgumentException($"Splitting the login on ':' should result in either 1 or 2 entries (u, u:p) but {usernameAndMaybePassword.Length} entries were returned", nameof(rpcLogin));
                _rpcUsername = usernameAndMaybePassword[0];
                _rpcPassword = usernameAndMaybePassword.Length == 2 ? usernameAndMaybePassword[1] : string.Empty;
            }

            _rpcServerReady = new Lazy<Task<bool>>(async () => await IsRpcServerHealthy(TimeSpan.FromMinutes(1)));
        }
        
        private async Task<string> JsonRpcAsync<TParameters>(string method, TParameters parameters, string? id = null, bool waitForHealthCheck = true, CancellationToken cancellationToken = default)
        {
            if (waitForHealthCheck) await _rpcServerReady.Value;
            var request = new MoneroRpcRequest<object>(method: method, parameters: parameters ?? new object(), id: id);
            var requestContent = new StringContent(
                JsonSerializer.Serialize(request, _jsonSerializerOptions),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            /* `NetworkCredentials` supports the case of the username/password being null for us */
            var credentials = new CredentialCache { { new Uri(_rpcUri), "Digest", new NetworkCredential(_rpcUsername, _rpcPassword) } };
            var httpClientHandler = new HttpClientHandler
            {
                PreAuthenticate = false,
                Credentials = credentials
            };
            /* If we are going to accept self signed SSL certs from the monero-wallet-rpc server then we need to accept cert the server creates */
            if (_acceptSelfSignedSslCerts)
            {
                httpClientHandler.ServerCertificateCustomValidationCallback += (_, _, _, _) => true;
            }
            using var httpClient = new HttpClient(httpClientHandler);
            using var httpResponse = await httpClient.PostAsync(_rpcUri, requestContent, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            return await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        }

        public async Task<IMoneroRpcResponse<TResult>?> JsonRpcAsync<TParameters, TResult>(
                string method,
                TParameters parameters,
                string? id = default,
                CancellationToken cancellationToken = default)
            where TResult : class
            where TParameters : class
        {
            var responseString = await JsonRpcAsync<object>(method, parameters, id, waitForHealthCheck: true, cancellationToken);
            return JsonSerializer.Deserialize<MoneroRpcResponse<TResult>>(responseString);
        }

        public Task<string> JsonRpcAsync<TParameters>(string method, TParameters parameters, string? id = null, CancellationToken cancellationToken = default)
        {
            return JsonRpcAsync(method, parameters ?? new object(), id, waitForHealthCheck: true, cancellationToken);
        }

        private async Task<bool> IsRpcServerHealthy(TimeSpan timeout)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < timeout)
            {
                try
                {
                    await JsonRpcAsync(
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

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                await JsonRpcAsync("store", new StoreParameters(), waitForHealthCheck: false).ConfigureAwait(false);
            }

            _disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(disposing: true);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize            
            GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        }
    }
}