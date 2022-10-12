using InventorySystem.Core.Services;
using InventorySystem.Membership.Entities;
using InventorySystem.Web.Helper;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventorySystem.Web.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    //[Authorize]
    public class PermissionController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMenuService _menuService;

        public PermissionController(RoleManager<Role> roleManager, UserManager<ApplicationUser> userManager, IMenuService menuService, IAuthorizationService authorizationService)
            :base(authorizationService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _menuService = menuService;
        }

        public async Task<ActionResult> Index(string roleId)
        {
            var model = new PermissionViewModel();
            var menus = _menuService.LoadAllMenus();
            var allPermissions = new List<ClaimsViewModel>();

            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);

            IList <ClaimsViewModel> roleClaimsViewModels = new List<ClaimsViewModel>();
            foreach (var menu in menus)
            {
                bool isGranted = false;
                string permissionType = string.IsNullOrWhiteSpace(menu.AreaName) ? "Permission" : menu.AreaName;
                string permission = string.Empty;
                
                if (string.IsNullOrWhiteSpace(menu.ControllerName) == false)
                    permission += $"{menu.ControllerName}.";
                if (string.IsNullOrWhiteSpace(menu.ActionName) == false)
                    permission += $"{menu.ActionName}";

                if(claims.Any(x => x.Type == permissionType && x.Value == permission))
                    isGranted = true;

                roleClaimsViewModels.Add(
                    new ClaimsViewModel 
                    { 
                        Type = permissionType, 
                        Value = permission, 
                        Selected = isGranted
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
