using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;


namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : IdentityDbContext<User>
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // One-to-Many: Un BidList peut avoir plusieurs Trades
            builder.Entity<BidList>()
                .HasMany(b => b.Trades)
                .WithOne(t => t.BidList)
                .HasForeignKey(t => t.BidListId);

            // One-to-Many: Un utilisateur peut avoir plusieurs trades
            builder.Entity<Trade>()
                .HasOne(t => t.User)
                .WithMany(u => u.Trades)
                .HasForeignKey(t => t.UserId);

            builder.Entity<Trade>()
                .HasOne(t => t.Rating)
                .WithMany(r => r.Trades)
                .HasForeignKey(t => t.RatingId);

            builder.Entity<BidList>()
                .HasOne(b => b.Rating)
                .WithMany(r => r.BidLists)
                .HasForeignKey(b => b.RatingId);            
        }

        // Ajout du DbSet pour l'entité BidList
        public DbSet<BidList> Bids { get; set; } = null!;
        public DbSet<Trade> Trades { get; set; } = null!;        
        public DbSet<CurvePoint> CurvePoints { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<RuleName> RuleNames { get; set; } = null!;
        public new DbSet<User> Users { get; set; }
    }
}