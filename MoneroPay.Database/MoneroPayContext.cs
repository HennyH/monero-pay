using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneroPay.Database.Entities;

namespace MoneroPay.Database
{
    public class MoneroPayContext : DbContext
    {
        public MoneroPayContext(DbContextOptions<MoneroPayContext> options) : base(options)
        { }

        public DbSet<MoneroWalletRpcContainer> MoneroWalletRpcContainers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseNpgsql("name=ConnectionStrings:MoneroPayContext")
            .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
            .UseLowerCaseNamingConvention();
    }
}