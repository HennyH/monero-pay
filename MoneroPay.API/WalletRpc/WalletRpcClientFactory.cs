using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoneroPay.API.Configuration;
using MoneroPay.API.Extensions;
using MoneroPay.API.Utilities;

namespace MoneroPay.API.WalletRpc
{
    public class WalletRpcClientFactory : IWalletRpcClientFactory, IAsyncDisposable
    {
        private readonly ILogger<WalletRpcClientFactory> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<string, Task<(WalletRpcProcess Process, WalletRpcCliParameters CliParameters)>> _walletNameToRpcProcess = new ConcurrentDictionary<string, Task<(WalletRpcProcess Process, WalletRpcCliParameters CliParameters)>>();
        private bool _disposed;

        public WalletRpcClientFactory(ILogger<WalletRpcClientFactory> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<IWalletRpcClient> CreateClientAsync(WalletRpcCliParameters cliParameters)
        {
            if (string.IsNullOrWhiteSpace(cliParameters.WalletFile)) throw new ArgumentNullException(nameof(cliParameters.WalletFile), "Support for launching a wallet rpc client without a --wallet-file argument is not supported.");
            if (string.IsNullOrWhiteSpace(cliParameters.RpcLogin)) throw new ArgumentNullException(nameof(cliParameters.RpcLogin), "Support for launching a wallet rpc client without a --rpc-login is not supported");
            if (cliParameters.RpcBindPort != null) throw new ArgumentException(nameof(cliParameters.RpcBindPort), "Support for launching a wallet rpc client on a preconfigured port has not been implemented");

            var (walletRpcProcess, prevCliParamters) = await _walletNameToRpcProcess.GetOrAddAsync(cliParameters.WalletFile, async (_) =>
            {
                var process = new WalletRpcProcess(
                    cliParameters: cliParameters,
                    logger: _serviceProvider.GetRequiredService<ILogger<WalletRpcProcess>>(),
                    mapper: _serviceProvider.GetRequiredService<IMapper>());
                if (!(await process.StartAsync())) throw new Exception($"Failed to start the monero-wallet-rpc service for wallet {cliParameters.WalletFile}");
                return (process, cliParameters);
            });
            
            if (prevCliParamters != cliParameters) throw new NotImplementedException($"Support for changing a particular wallets CLI settings at runtime is not supported");
            if (!walletRpcProcess.RpcPort.HasValue) throw new InvalidProgramException($"If the monero-wallet-rpc service started successfully it should always have an RpcPort in the absence of a coding bug.");

            return new WalletRpcClient(
                logger: _serviceProvider.GetRequiredService<ILogger<WalletRpcClient>>(),
                rpcUri: $"http://localhost:{walletRpcProcess.RpcPort}/json_rpc",
                rpcLogin: cliParameters.RpcLogin,
                getInformationLogs: () => walletRpcProcess.InformationData,
                getWarningLogs: () => walletRpcProcess.WarningData,
                getDebugLogs: () => walletRpcProcess.DebugData,
                getErrorLogs: () => walletRpcProcess.ErrorData
            );
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                await foreach (var (walletRpcProcess, _) in _walletNameToRpcProcess.Values.AsAsyncEnumerable())
                {
                    walletRpcProcess?.Dispose();
                }
            }

            _disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}