using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : IdentityDbContext<User>
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // Ajout du DbSet pour l'entit้ BidList
        public DbSet<BidList> Bids { get; set; } = null!;
        public DbSet<Trade> Trades { get; set; } = null!;        
        public DbSet<CurvePoint> CurvePoints { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<RuleName> RuleNames { get; set; } = null!;
        public new DbSet<User> Users { get; set; }
    }
}