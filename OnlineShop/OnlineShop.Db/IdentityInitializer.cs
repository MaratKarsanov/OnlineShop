using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@mail.ru";
            var password = "marMAR!123";
            if (roleManager.FindByNameAsync(Constants.AdministratorRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User 
                { 
                    Email = adminEmail, 
                    UserName = adminEmail,
                };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdministratorRoleName).Wait();
                }
            }
        }
    }
}
