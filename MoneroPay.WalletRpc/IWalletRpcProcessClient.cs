using System.Collections.Generic;

namespace MoneroPay.WalletRpc
{
    public interface IWalletRpcProcessClient : IWalletRpcClient
    {
        public IEnumerable<string> InformationLogs { get; }
        public IEnumerable<string> WarningLogs { get; }
        public IEnumerable<string> DebugLogs { get; }
        public IEnumerable<string> ErrorLogs { get; }
    }
}