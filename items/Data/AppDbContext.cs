using items.Models;
using Microsoft.EntityFrameworkCore;

namespace items.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionStr = String.Format("Host={0};Port={1};Database={2};Username={3};Password={4}",
                configuration.GetValue<string>("PGSQL_HOST"),
                configuration.GetValue<string>("PGSQL_PORT"),
                configuration.GetValue<string>("PGSQL_DB"),
                configuration.GetValue<string>("PGSQL_USER"),
                configuration.GetValue<string>("PGSQL_PASSWORD")
                );
            optionsBuilder.UseNpgsql(connectionStr);

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
