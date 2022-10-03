using InventorySystem.Membership.Entities;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Security.Claims;

namespace InventorySystem.Web.Helper
{
    public static class ClaimsHelper
    {
        public static void GetPermissions(this List<RoleClaimsViewModel> allPermissions, Type policy, string roleId)
        {
            FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                allPermissions.Add(new RoleClaimsViewModel { Value = fi.GetValue(null).ToString(), Type = "Permissions" });
            }
        }

        public static async Task AddPermissionClaim(this RoleManager<Role> roleManager, Role role, string permission, string type)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            //TODO: changed for permission
            if (!allClaims.Any(a => a.Type == type && a.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim(type, permission));
            }
        }
    }
}
