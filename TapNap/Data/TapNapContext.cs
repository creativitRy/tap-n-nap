using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TapNap.Areas.Identity.Data;

namespace TapNap.Models
{
    public class TapNapContext : IdentityDbContext<TapNapUser>
    {
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Rented> Renteds { get; set; }

        public TapNapContext(DbContextOptions<TapNapContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<TapNapUser>().HasMany(u => u.Renteds).WithOne(r => r.User).OnDelete(DeleteBehavior.SetNull);
            //builder.Entity<TapNapUser>().HasMany(u => u.Beds).WithOne(b => b.User).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Bed>(e =>
            {
                e.HasOne(b => b.User)
                    .WithMany(u => u.Beds)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<Rented>(e =>
            {
                e.HasOne(r => r.Bed)
                    .WithMany(b => b.Renteds)
                    .OnDelete(DeleteBehavior.SetNull);
                e.HasOne(r => r.User)
                    .WithMany(u => u.Renteds)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
