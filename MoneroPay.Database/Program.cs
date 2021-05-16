using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MoneroPay.Database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<MoneroPayContext>();
                });
    }
}
