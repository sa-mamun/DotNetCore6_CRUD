using InventorySystem.Domain;
using InventorySystem.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace InventorySystem.Web.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role(SeedRoles.SuperAdmin.ToString()));
        }
    }
}
