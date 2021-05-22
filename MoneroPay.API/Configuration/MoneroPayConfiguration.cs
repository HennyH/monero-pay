using System.Runtime.InteropServices;

namespace MoneroPay.API.Configuration
{
    public class MoneroPayConfiguration : IMoneroPayConfiguration
    {
        public string MonerodWalletRpcPath { get; set; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "monero-wallet-rpc.exe"
            : "monero-wallet-rpc";
        public ushort WalletRpcPortStart { get; set; } = 28090;
        public ushort WalletRpcPortEnd { get; set; } = 28099;
        public string MonerodHost { get; set; } = "localhost";
        public ushort MonerodPort { get; set; } = 28081;
    }
}