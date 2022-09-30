using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Web.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IAuthorizationService authorizationService)
            :base(authorizationService)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
