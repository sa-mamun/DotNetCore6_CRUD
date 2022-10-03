using InventorySystem.Core.Services;
using InventorySystem.Membership.Entities;
using InventorySystem.Web.Helper;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMenuService _menuService;

        public PermissionController(RoleManager<Role> roleManager, IMenuService menuService)
        {
            _roleManager = roleManager;
            _menuService = menuService;
        }

        public async Task<ActionResult> Index(string roleId)
        {
            var model = new PermissionViewModel();
            //var allPermissions = new List<RoleClaimsViewModel>();
            //allPermissions.GetPermissions(typeof(Permissions.Permissions.Products), roleId);
            //var role = await _roleManager.FindByIdAsync(roleId);
            //model.RoleId = roleId;
            //var claims = await _roleManager.GetClaimsAsync(role);
            //var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            //var roleClaimValues = claims.Select(a => a.Value).ToList();
            //var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            //foreach (var permission in allPermissions)
            //{
            //    if (authorizedClaims.Any(a => a == permission.Value))
            //    {
            //        permission.Selected = true;
            //    }
            //}

            var menus = _menuService.LoadAllMenus();
            IList <RoleClaimsViewModel> roleClaimsViewModels = new List<RoleClaimsViewModel>();
            foreach (var menu in menus)
            {
                string permission = string.Empty;
                
                if (string.IsNullOrWhiteSpace(menu.ControllerName) == false)
                    permission += $"{menu.ControllerName}.";
                if (string.IsNullOrWhiteSpace(menu.ActionName) == false)
                    permission += $"{menu.ActionName}";

                roleClaimsViewModels.Add(
                    new RoleClaimsViewModel 
                    { 
                        Type = string.IsNullOrWhiteSpace(menu.AreaName) ? "Permission" : menu.AreaName, 
                        Value = permission, 
                        Selected = false 
                    });
            }

            model.RoleClaims = roleClaimsViewModels;
            return View(model);
        }
        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                //TODO: changed for permission
                string area = string.IsNullOrWhiteSpace(claim.Type) ? "Permission" : claim.Type;
                await _roleManager.AddPermissionClaim(role, $"{claim.Value}", area);
            }
            return RedirectToAction("Index", new { roleId = model.RoleId });
        }
    }
}
