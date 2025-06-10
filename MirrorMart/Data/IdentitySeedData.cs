using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MirrorMart.Data
{
    public static class IdentitySeedData
    {
        public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Roles to create
            string[] roleNames = { "Admin", "Guest" };

            // Create Roles if they don't exist
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed Admin User
            var adminEmail = "admin@mirrormart.com";
            var adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed Guest User
            var guestEmail = "guest@mirrormart.com";
            var guestPassword = "Guest@123";

            var guestUser = await userManager.FindByEmailAsync(guestEmail);
            if (guestUser == null)
            {
                guestUser = new IdentityUser
                {
                    UserName = guestEmail,
                    Email = guestEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(guestUser, guestPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(guestUser, "Guest");
                }
            }
        }
    }
}
