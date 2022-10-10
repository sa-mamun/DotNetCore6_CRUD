using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IAuthorizationService authorizationService)
            :base(authorizationService)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
