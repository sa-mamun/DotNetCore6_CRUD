namespace InventorySystem.Web.Models
{
    public class PermissionViewModel
    {
        public string RoleId { get; set; }
        public IList<ClaimsViewModel> RoleClaims { get; set; }
    }
    public class ClaimsViewModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }
}
