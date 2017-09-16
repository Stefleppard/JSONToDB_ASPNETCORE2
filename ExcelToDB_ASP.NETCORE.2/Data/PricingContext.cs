using JSONToDB_ASPNETCORE2.Models;
using Microsoft.EntityFrameworkCore;

namespace JSONToDB_ASPNETCORE2.Data
{
    public class PricingContext : DbContext
    {
        public PricingContext(DbContextOptions<PricingContext> options) : base(options)
        {
        }

        public DbSet<PriceInfo> PriceInfo { get; set; }
        //public object Date { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceInfo>().ToTable("PriceInfo");
        }
    }
}
