using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Permissions
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            var routeData = _httpContextAccessor.HttpContext.GetRouteData();

            var areaName = routeData?.Values["area"]?.ToString();
            var area = string.IsNullOrWhiteSpace(areaName) ? "Permission" : areaName;

            var splittedPermission = requirement.Permission.Split('.');

            //TODO: Need to fix way of checking the permission
            var permissionss = context.User.Claims.Where(x => x.Type == area &&
                                                                x.Value == $"{splittedPermission[1]}.{splittedPermission[2]}");

            if (permissionss.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
