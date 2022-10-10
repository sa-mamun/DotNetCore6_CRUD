﻿using InventorySystem.Membership.Entities;
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
        public RolesController(RoleManager<Role> roleManager, IAuthorizationService authorizationService)
            :base(authorizationService)
        {
            _roleManager = roleManager;
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

            return RedirectToAction("Index");
        }
    }
}
