using MirrorMart.Models;
using Microsoft.EntityFrameworkCore;

namespace MirrorMart.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Apply pending migrations if any
            context.Database.Migrate();

            // Check if data already exists
            if (context.Mirrors.Any())
            {
                return; // DB has been seeded
            }

            var mirrors = new Mirror[]
            {
                new Mirror{Type="Wall Mirror", Price=25.00M, Material="Wood", Size="24x36 inches", Shape="Rectangle"},
                new Mirror{Type="Standing Mirror", Price=50.00M, Material="Metal", Size="60x24 inches", Shape="Oval"},
                new Mirror{Type="Bathroom Mirror", Price=30.00M, Material="Plastic", Size="20x30 inches", Shape="Square"},
                new Mirror{Type="Decorative Mirror", Price=45.00M, Material="Glass", Size="18x18 inches", Shape="Round"},
                new Mirror{Type="Vintage Mirror", Price=70.00M, Material="Wood", Size="28x40 inches", Shape="Rectangle"},
                new Mirror{Type="Compact Mirror", Price=15.00M, Material="Metal", Size="5x5 inches", Shape="Circle"}
            };

            context.Mirrors.AddRange(mirrors);
            context.SaveChanges();
        }
    }
}