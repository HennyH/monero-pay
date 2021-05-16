using System.Threading.Tasks;
using MoneroPay.API.Configuration;

namespace MoneroPay.API.WalletRpc
{
    public interface IWalletRpcClientFactory
    {
        public Task<IWalletRpcClient> CreateClientAsync(WalletRpcCliParameters cliParameters);
    }
}