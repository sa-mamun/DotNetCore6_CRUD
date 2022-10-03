using InventorySystem.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Policy;

namespace InventorySystem.Web.Controllers
{
    //[CustomAuth]
    public class BaseController : Controller
    {
        public readonly IAuthorizationService _authorizationService;

        public BaseController(IAuthorizationService AuthorizationService)
        {
            _authorizationService = AuthorizationService;
        }
         
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.IsInRole("SuperAdmin") == false)
            {
                var areaName = ((ControllerBase)context.Controller).ControllerContext.RouteData.Values["area"];
                var controllerName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
                var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

                areaName = string.IsNullOrWhiteSpace(areaName?.ToString()) ? "Permission" : areaName;
                if (_authorizationService.AuthorizeAsync(User, $"{areaName}.{controllerName}.{actionName}").Result.Succeeded == false)
                {
                    context.Result = new RedirectResult("Account/AccessDenied/");
                    return;
                }
            }
        }
    }
}
