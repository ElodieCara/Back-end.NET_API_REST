using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Controllers;

namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // Ajout du DbSet pour l'entité BidList
        public DbSet<BidList> Bids { get; set; } = null!;
        public DbSet<Trade> Trades { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CurvePoint> CurvePoints { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<RuleName> RuleNames { get; set; } = null!;
    }
}