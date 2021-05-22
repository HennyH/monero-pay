namespace MoneroPay.API.Configuration
{
    public interface IMoneroPayConfiguration
    {
        string MonerodHost { get; }
        ushort MonerodPort { get; }
        string MonerodWalletRpcPath { get; }
        ushort WalletRpcPortStart { get; }
        ushort WalletRpcPortEnd { get; }
    }
}