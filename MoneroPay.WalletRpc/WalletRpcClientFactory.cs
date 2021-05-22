using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MoneroPay.WalletRpc
{
    public class WalletRpcClientFactory : IWalletRpcClientFactory
    {
        private readonly ILogger<WalletRpcClientFactory> _logger;
        private readonly IServiceProvider _serviceProvider;
        public WalletRpcClientFactory(ILogger<WalletRpcClientFactory> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task<IWalletRpcClient> CreateClientAsync(string rpcUri, string? rpcLogin)
        {
            IWalletRpcClient client = new WalletRpcClient(
                logger: _serviceProvider.GetRequiredService<Logger<WalletRpcClient>>(),
                rpcUri: rpcUri,
                rpcLogin: rpcLogin
            );
            _logger.LogInformation($"Created client for rpc uri {rpcUri}");
            return Task.FromResult(client);
        }
    }
}