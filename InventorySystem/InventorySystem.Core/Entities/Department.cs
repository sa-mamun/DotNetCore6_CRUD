using InventorySystem.Data;

namespace InventorySystem.Core.Entities;

public class Department : AuditableEntity<long>
{
    public string Name { get; set; }
}
