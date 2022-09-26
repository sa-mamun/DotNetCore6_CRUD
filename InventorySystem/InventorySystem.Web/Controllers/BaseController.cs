﻿using InventorySystem.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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

            //var areaName = ((ControllerBase)context.Controller).ControllerContext.RouteData.DataTokens["areas"];
            var controllerName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

            if (_authorizationService.AuthorizeAsync(User, $"{controllerName}.{actionName}").Result.Succeeded)
            {
                //"Permissions.Products.View"
            }

        }


        //public bool IsAuthorizedAction(string permission)
        //{
        //    //if (_authorizationService.AuthorizeAsync(User, permission).Result.Succeeded)
        //    //    return true;

        //    return false;
        //}
    }
}
