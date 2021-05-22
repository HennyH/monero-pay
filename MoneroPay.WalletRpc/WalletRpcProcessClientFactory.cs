using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoneroPay.SharedUtilities;
using MoneroPay.WalletRpc.Models;

namespace MoneroPay.WalletRpc
{
    public class WalletRpcProcessClientFactory : IWalletRpcProcessClientFactory, IAsyncDisposable
    {
        private readonly ILogger<WalletRpcProcessClientFactory> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<string, Task<(WalletRpcProcess Process, WalletRpcCliParameters CliParameters)>> _walletNameToRpcProcess = new();
        private readonly ConcurrentBag<WalletRpcClient> _clients = new();
        private bool _disposed;

        public WalletRpcProcessClientFactory(ILogger<WalletRpcProcessClientFactory> logger,  IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<IWalletRpcProcessClient> CreateClientAsync(string moneroWalletRpcPath, WalletRpcCliParameters cliParameters, ushort portRangeLower = 28082, ushort portRangeUpper = 28092)
        {
            if (string.IsNullOrWhiteSpace(cliParameters.DaemonHost)) throw new ArgumentException("The daemon host must be specified to create a monero wallet rpc client", nameof(cliParameters));
            if (string.IsNullOrWhiteSpace(cliParameters.WalletFile)) throw new ArgumentException("Support for launching a wallet rpc client without a --wallet-file argument is not supported.", nameof(cliParameters));
            if (string.IsNullOrWhiteSpace(cliParameters.RpcLogin)) throw new ArgumentException("Support for launching a wallet rpc client without a --rpc-login is not supported", nameof(cliParameters));
            if (cliParameters.RpcBindPort != null) throw new ArgumentException("Support for launching a wallet rpc client on a preconfigured port has not been implemented", nameof(cliParameters));

            var (walletRpcProcess, prevCliParamters) = await _walletNameToRpcProcess.GetOrAddAsync(cliParameters.WalletFile, async (_) =>
            {
                var process = new WalletRpcProcess(
                    logger: _serviceProvider.GetRequiredService<ILogger<WalletRpcProcess>>(),
                    moneroWalletRpcPath: moneroWalletRpcPath,
                    portRangeLower: portRangeLower,
                    portRangeUpper: portRangeUpper,
                    cliParameters: cliParameters
                );
                if (!await process.StartAsync()) throw new Exception($"Failed to start the monero-wallet-rpc service for wallet {cliParameters.WalletFile}");
                _logger.LogInformation($"Launched monero-wallet-rpc process on port {process.RpcPort} for wallet {cliParameters.WalletFile}");
                return (process, cliParameters);
            });
            
            if (prevCliParamters != cliParameters) throw new NotImplementedException($"Support for changing a particular wallets CLI settings at runtime is not supported");
            if (!walletRpcProcess.RpcPort.HasValue) throw new InvalidProgramException($"If the monero-wallet-rpc service started successfully it should always have an RpcPort in the absence of a coding bug.");

            var client = new WalletRpcProcessClient(
                logger: _serviceProvider.GetRequiredService<ILogger<WalletRpcClient>>(),
                rpcUri: walletRpcProcess.RpcUri,
                rpcLogin: cliParameters.RpcLogin,
                getInformationLogs: () => walletRpcProcess.InformationData,
                getWarningLogs: () => walletRpcProcess.WarningData,
                getDebugLogs: () => walletRpcProcess.DebugData,
                getErrorLogs: () => walletRpcProcess.ErrorData
            );
            _clients.Add(client);
            return client;
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // dispose of the wallet rpc clients we created before
                // we dispose of the wallet rpc processess because the clients
                // will try issue a call to 'store' (aka save) the wallet.
                foreach (var client in _clients)
                {
                    if (client == null) continue;
                    await client.DisposeAsync();
                }

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
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
            GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        }
    }
}