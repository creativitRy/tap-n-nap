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

            var superuser = "8441d71a-12e6-4385-a5b8-2f7f23f9a9fd";

            builder.Entity<Bed>().HasData(new Bed() {UserID = superuser, BedID = 0, Address = "2101 Nueces St, Austin, TX 78705", PricePerHour = (decimal)15.99, Description = "This is a fairly large bed for a couple to enjoy a nice nap, and bright lighting if needed"},
                                          new Bed() { UserID = superuser, BedID = 1, Address = "2110 Rio Grande St, Austin, TX 78705", PricePerHour = (decimal)20.99, Description = "A large room with a modern wooden furnishing and and colors. A great place to crash if the day gets too long." },
                new Bed() { UserID = superuser, BedID = 2, Address = "502 Elmwood Pl, Austin, TX 78705", PricePerHour = (decimal)17.88, Description = "An incredibly modern and cozy bed with plenty of space to roll around when napping. The attached bathroom will give you a great place to freshen up after waking up." },
                new Bed() { UserID = superuser, BedID = 3, Address = "3004 University Ave, Austin, TX 78705", PricePerHour = (decimal)20.99, Description = "A circular bed with plenty of room to sprawl out in, but still lots of space in the room that gives a sense of freedom. Comes with a giant ultra-wide LCD TV  and a desk if anything comes up during your nap." },
                new Bed() { UserID = superuser, BedID = 4, Address = "1013 W 23rd St, Austin, TX 78705", PricePerHour = (decimal)30, Description = "A moody room with a queen sized bed, lots of pillows and warm blankets. For when you just don't have the bests of days and just want somewhere to crash." },
                new Bed() { UserID = superuser, BedID = 5, Address = "2207 E 21st St, Austin, TX 78722", PricePerHour = (decimal)20.99, Description = "A passion filled room with a queen sized bed and plenty of room for anything extra you need." });

            builder.Entity<Picture>().HasData(new Picture(){BedID = 0, Src = "/imageAssets/beds/2101-Nueces-St.jpg" },
                new Picture() { BedID = 1, Src = "/imageAssets/beds/2110-Rio-Grande-St.jpg" },
                new Picture() { BedID = 2, Src = "/imageAssets/beds/502-Elmwood-Pl.jpg" },
                new Picture() { BedID = 3, Src = "/imageAssets/beds/3004-University-Ave.jpg" },
                new Picture() { BedID = 1, Src = "/imageAssets/beds/2101-Nueces-St.jpg" },
                new Picture() { BedID = 5, Src = "/imageAssets/beds/2207-E-21st-St.jpg" });
        }
    }
}
