using InventorySystem.Core.Services;
using InventorySystem.Membership.Entities;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Web.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    //[Authorize]
    public class RolesController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMenuService _menuService;

        public RolesController(RoleManager<Role> roleManager, UserManager<ApplicationUser> userManager, IMenuService menuService, IAuthorizationService authorizationService)
            :base(authorizationService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new Role(roleName.Trim()));
            }

            

            //_userManager.AddPermissionClaim(User, $"{claim.Value}", area)

            return RedirectToAction("Index");
        }
    }
}
