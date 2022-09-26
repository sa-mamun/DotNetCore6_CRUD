using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InventorySystem.Web.Helper
{
    public class CustomAuth : ActionFilterAttribute
    {
        public readonly IAuthorizationService _authorizationService;

        public CustomAuth(IAuthorizationService AuthorizationService)
        {
            _authorizationService = AuthorizationService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

        }

        //public bool IsAuthorizedAction(string permission)
        //{
        //    //if (_authorizationService.AuthorizeAsync(User, permission).Result.Succeeded)
        //    //    return true;

        //    return false;
        //}
    }
}
