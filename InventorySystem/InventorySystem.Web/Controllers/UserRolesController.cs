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
    public class UserRolesController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMenuService _menuService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public UserRolesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMenuService menuService, RoleManager<Role> roleManager, IAuthorizationService authorizationService)
            : base(authorizationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _menuService = menuService;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string userId)
        {
            var rolesViewModel = new List<UserRolesViewModel>();
            var userClaimsViewModel = new List<ClaimsViewModel>();

            var user = await _userManager.FindByIdAsync(userId);
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                rolesViewModel.Add(userRolesViewModel);
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var menus = _menuService.LoadAllMenus();

            foreach (var menu in menus)
            {
                bool isGranted = false;
                string permissionType = string.IsNullOrWhiteSpace(menu.AreaName) ? "Permission" : menu.AreaName;
                string permission = string.Empty;

                if (string.IsNullOrWhiteSpace(menu.ControllerName) == false)
                    permission += $"{menu.ControllerName}.";
                if (string.IsNullOrWhiteSpace(menu.ActionName) == false)
                    permission += $"{menu.ActionName}";

                if (userClaims.Any(x => x.Type == permissionType && x.Value == permission))
                    isGranted = true;

                userClaimsViewModel.Add(
                    new ClaimsViewModel
                    {
                        Type = permissionType,
                        Value = permission,
                        Selected = isGranted
                    });
            }

            var model = new ManageUserRolesViewModel()
            {
                UserId = userId,
                UserRoles = rolesViewModel,
                Permissions = userClaimsViewModel
            };

            return View(model);
        }

        public async Task<IActionResult> Update(string id, ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            //await Seeds.DefaultUsers.SeedSuperAdminAsync(_userManager, _roleManager);

            var userClaims = await _userManager.GetClaimsAsync(user);

            foreach (var claim in userClaims)
            {
                await _userManager.RemoveClaimAsync(user, claim);
            }

            var selectedClaims = model.Permissions.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                //TODO: changed for permission
                string area = string.IsNullOrWhiteSpace(claim.Type) ? "Permission" : claim.Type;
                await _userManager.AddPermissionClaim(user, $"{claim.Value}", area);
            }

            //_signInManager.SignOutAsync(user);

            //await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Index", new { userId = id });
        }
    }
}
