using InventorySystem.Data;

namespace InventorySystem.Core.Entities;

public class Employee : AuditableEntity<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }

    public Department Department { get; set; }
    public long DepartmentId { get; set; }
    public Designation Designation { get; set; }
    public long DesignationId { get; set; }
}
