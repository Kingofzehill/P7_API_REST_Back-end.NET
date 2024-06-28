using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using System.Security.Principal;

namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // TODO (FIX02) deactivate Users DbSet in LocalDbContext.cs as users will be managed with ASP.NET Identity.
        public DbSet<User> Users { get; set;}
        // (UPD001) add data classes DbSets.
        public DbSet<BidList> Bids { get; set; }
        public DbSet<CurvePoint> CurvePoints { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RuleName> Rules { get; set; }
        public DbSet<Trade> Trades { get; set; }

    }
}