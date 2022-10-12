using InventorySystem.Membership.Entities;

namespace InventorySystem.Web.Models
{
    public class RolesWithIndividualPermissionViewModel
    {
        public IList<Role> Roles { get; set; }
        public IList<ClaimsViewModel> Permissions { get; set; }
    }
}
