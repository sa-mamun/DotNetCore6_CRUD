using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Web.Controllers
{
    public class BaseController : Controller
    {
        internal readonly IAuthorizationService _authorizationService;

        public BaseController(IAuthorizationService AuthorizationService)
        {
            _authorizationService = AuthorizationService;
        }

        public bool IsAuthorizedAction(string permission)
        {
            if (_authorizationService.AuthorizeAsync(User, permission).Result.Succeeded)
                return true;

            return false;
        }
    }
}
