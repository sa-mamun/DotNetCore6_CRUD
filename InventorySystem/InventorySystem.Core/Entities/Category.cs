using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Entities;

public class Category : AuditableEntity<long>
{
    public string Name { get; set; }
    public IList<Product> Products { get; set; }
}
