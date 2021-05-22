using System.Threading.Tasks;
using MoneroPay.WalletRpc.Models;

namespace MoneroPay.WalletRpc
{
    public interface IWalletRpcClientFactory
    {
        public Task<IWalletRpcClient> CreateClientAsync(string rpcUri, string? rpcLogin);
    }
}