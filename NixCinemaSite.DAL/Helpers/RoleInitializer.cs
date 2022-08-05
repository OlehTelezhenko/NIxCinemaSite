using Microsoft.AspNetCore.Identity;
using NixCinemaSite.DAL.Entities.Identity;

namespace NixCinemaSite.DAL.Helpers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var Admin = new User()
            {
                DateOfBirth = DateTime.Now,
                UserName = "Admin",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = "123456789",
                Id = Guid.NewGuid().ToString(),
            };
            var Moderator = new User()
            {
                DateOfBirth = DateTime.Now,
                UserName = "Moderator",
                Email = "Moderator@Moderator.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = "123123123",
                Id = Guid.NewGuid().ToString(),
            }; 
            var User = new User()
            {
                DateOfBirth = DateTime.Now,
                UserName = "User",
                Email = "User@User.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = "323232322",
                Id = Guid.NewGuid().ToString(),
            };
            string password = "!23Qwe";

            // TODO RoleInitializer вынести создаваемые роли в конфигурации
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (await roleManager.FindByNameAsync("Moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Moderator"));
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (await userManager.FindByEmailAsync(Admin.Email) == null)
            {
                IdentityResult result = await userManager.CreateAsync(Admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(Admin, "Admin");
                }
            }
            if (await userManager.FindByEmailAsync(Moderator.Email) == null)
            {
                IdentityResult result = await userManager.CreateAsync(Moderator, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(Moderator, "Moderator");
                }
            }
            if (await userManager.FindByEmailAsync(User.Email) == null)
            {
                IdentityResult result = await userManager.CreateAsync(User, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(User, "User");
                }
            }
        }
    }
}
