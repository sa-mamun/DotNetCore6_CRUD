using InventorySystem.Data;

namespace InventorySystem.Core.Entities;

public class Designation : AuditableEntity<long>
{
    public string Name { get; set; }

}
