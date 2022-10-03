using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;

namespace InventorySystem.Web.Permissions
{
    internal class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options, IHttpContextAccessor httpContextAccessor)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var routeData = _httpContextAccessor.HttpContext.GetRouteData();

            var areaName = routeData?.Values["area"]?.ToString();
            var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;

            if (policyName.StartsWith(area, StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new PermissionRequirement(policyName));
                return Task.FromResult(policy.Build());
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();
    }
}
