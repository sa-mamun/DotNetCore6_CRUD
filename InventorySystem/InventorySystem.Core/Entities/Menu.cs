using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Entities
{
    public class Menu : AuditableEntity<int>
    {
        public long RootMenuId { get; set; }
        public long ActionName { get; set; }
        public long MenuName { get; set; }
    }
}
