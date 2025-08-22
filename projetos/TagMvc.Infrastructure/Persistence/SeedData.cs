using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TagMvc.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace TagMvc.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();

            string[] roleNames = { "Admin", "Member" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminUser = await userManager.FindByEmailAsync("admin@localhost.com");

            if (adminUser == null)
            {
                var newAdminUser = new Usuario { UserName = "admin", Email = "admin@localhost.com", Nome = "Administrador", EmailConfirmed = true };
                var result = await userManager.CreateAsync(newAdminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }
        }
    }
}