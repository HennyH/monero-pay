using System.Threading.Tasks;
using MoneroPay.WalletRpc.Models;

namespace MoneroPay.WalletRpc
{
    public interface IWalletRpcProcessClientFactory
    {
        public Task<IWalletRpcProcessClient> CreateClientAsync(string moneroWalletRpcPath, WalletRpcCliParameters cliParameters, ushort portRangeLower, ushort portRangeUpper);
    }
}