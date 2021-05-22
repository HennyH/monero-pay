using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MoneroPay.Database
{
    public class MoneroPayContext : DbContext
    {
        public MoneroPayContext(DbContextOptions<MoneroPayContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseNpgsql("name=ConnectionStrings:MoneroPayContext")
            .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
            .UseLowerCaseNamingConvention();
    }
}