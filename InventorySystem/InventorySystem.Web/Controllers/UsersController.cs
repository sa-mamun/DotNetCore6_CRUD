using InventorySystem.Membership.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Web.Controllers
{
    //[Authorize(Roles ="SuperAdmin")]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService)
            :base(authorizationService)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            //var allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
            var allUsersExceptCurrentUser = await _userManager.Users.ToListAsync();
            return View(allUsersExceptCurrentUser);
        }
    }
}
