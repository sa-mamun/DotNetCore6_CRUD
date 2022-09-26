using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static InventorySystem.Web.Permissions.Permissions;

namespace InventorySystem.Web.Controllers
{

    public class ProductController : BaseController
    {
        public ProductController(IAuthorizationService authorizationService)
            : base(authorizationService)
        {

        }

        //[Authorize(Policy = "YouNeedToBe18ToDoThis")]
        public IActionResult Index()
        {
            //if ((_authorizationService.AuthorizeAsync(User, Permissions.Products.Create)).Result.Succeeded)
            //    throw new Exception("Permission Denied.");

            //var isAuthorized = IsAuthorizedAction(Products.View);

            //if (!isAuthorized)
            //    return RedirectToAction("AccessDenied", "Account", new { area = "Identity" });

            //https://localhost:44357/Identity/Account/AccessDenied?ReturnUrl=%2Fuserroles%3FuserId%3Dde3eb784-f652-4291-8e7c-1e028bfc8f49

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
