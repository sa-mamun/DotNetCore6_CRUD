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
        public RootMenu RootMenu{ get; set; }
        public string ActionName { get; set; }
        public string MenuName { get; set; }
    }
}
