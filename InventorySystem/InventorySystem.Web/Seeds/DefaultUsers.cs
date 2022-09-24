using InventorySystem.Domain;
using InventorySystem.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace InventorySystem.Web.Seeds
{
    public static class DefaultUsers
    {
        //public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
        //{
        //    var defaultUser = new ApplicationUser
        //    {
        //        UserName = "basicuser@gmail.com",
        //        Email = "basicuser@gmail.com",
        //        EmailConfirmed = true
        //    };

        //    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
        //    await userManager.AddToRoleAsync(defaultUser, "Basic");

        //    //if (userManager.Users.All(u => u.Id != defaultUser.Id))
        //    //{
        //    //    var user = await userManager.FindByEmailAsync(defaultUser.Email);
        //    //    if (user == null)
        //    //    {
        //    //        await userManager.CreateAsync(defaultUser, "123Pa$$word!");
        //    //        await userManager.AddToRoleAsync(defaultUser, "Basic");
        //    //    }
        //    //}
        //}

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, SeedRoles.SuperAdmin.ToString());
                }
            }
        }
    }
}
