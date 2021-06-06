using System.Text.Json;
using System.Threading.Tasks;
using MoneroPay.WalletRpc;
using MoneroPay.WalletRpc.Models;
using Xunit;
using Xunit.Abstractions;

namespace MoneroPay.Tests
{
    public class UnitTest1 : ApiTestFixture
    {
        public UnitTest1(ITestOutputHelper outputHelper, ApiWebApplicationFactory factory) : base(outputHelper, factory)
        { }

        [Fact]
        public async Task Test1()
        {
            var rpcClientFactory = GetRequiredService<IWalletRpcProcessClientFactory>();
            var client = await rpcClientFactory.CreateClientAsync(
                moneroWalletRpcPath: @"C:\Program Files\Monero GUI Wallet\monero-wallet-rpc.exe",
                cliParameters: new WalletRpcCliParameters
                {
                    WalletFile = @"C:\ProgramData\bitmonero\wallets\artistwallet",
                    RpcLogin = "user:pass",
                    DaemonHost = "localhost",
                    DaemonPort = 28081,
                    Testnet = true,
                    Password = "",
                    LogLevel = 2
                },
                portRangeLower: 28090,
                portRangeUpper: 28099);
            await Task.Delay(1000);
            try
            {
                var x = await client.JsonRpcAsync<GetAddressParameters, GetAddressResult>("get_address", new GetAddressParameters(0, new()));
                Assert.Null(x.Error);
                _output.WriteLine(JsonSerializer.Serialize(x));
            }
            catch {}
            foreach (var entry in client.ErrorLogs)
            {
                _output.WriteLine(entry);
            }
        }
    }
}
