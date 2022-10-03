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
            var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;

            var permissionss = context.User.Claims.Where(x => x.Type == area &&
                                                                x.Value == requirement.Permission);
            if (permissionss.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
