using InventorySystem.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Security.Policy;

namespace InventorySystem.Web.Controllers
{
    //[CustomAuth]
    public class BaseController : Controller
    {
        public readonly IAuthorizationService _authorizationService;

        public BaseController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
         
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.IsInRole("SuperAdmin") == false)
            {
                var areaName = ((ControllerBase)context.Controller).ControllerContext.RouteData.Values["area"]?.ToString();
                var controllerName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
                var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

                //var allDataPermission = User.Claims.Any(x => x.Type == $"{areaName}.{controllerName}.{actionName}" && x.Value == "True");

                string policyName = string.Empty;
                if (string.IsNullOrWhiteSpace(areaName) == false)
                    policyName = $"{areaName}.";

                policyName += $"{controllerName}.{actionName}";

                if (_authorizationService.AuthorizeAsync(User, policyName).Result.Succeeded == false)
                {
                    context.Result = new RedirectResult("Account/AccessDenied/");
                    return;
                }
            }
        }
    }
}
