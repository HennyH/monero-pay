using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoneroPay.API.Configuration;
using MoneroPay.API.Models.Monero;
using MoneroPay.API.WalletRpc;
using Xunit;
using Xunit.Abstractions;

namespace MoneroPay.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public async Task Test1()
        {
            var services = new ServiceCollection()
                .AddLogging(x => x.AddConsole())
                .AddAutoMapper(typeof(MoneroPay.API.Startup))
                .AddHttpClient()
                .AddSingleton<WalletRpcClientFactory>();
            var serviceProvider = services.BuildServiceProvider();
            await using (var rpcClientFactory = serviceProvider.GetRequiredService<WalletRpcClientFactory>())
            {
                var client = await rpcClientFactory.CreateClientAsync(new WalletRpcCliParameters
                {
                    WalletFile = @"C:\ProgramData\bitmonero\wallets\artistwallet",
                    RpcLogin = "user:pass",
                    DaemonHost = "localhost",
                    DaemonPort = 28081,
                    Testnet = true,
                    Password = "",
                    LogLevel = 2
                });
                await Task.Delay(1000);
                try
                {
                    var x = await client.JsonRpcAsync<GetAddressRpcParameters, GetAddressRpcResult>("get_address", new GetAddressRpcParameters(0));
                    output.WriteLine(JsonSerializer.Serialize(x));
                }
                catch {}
                foreach (var entry in client.ErrorLogs)
                {
                    output.WriteLine(entry);
                }
            }
        }
    }
}
