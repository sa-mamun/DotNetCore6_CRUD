using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Entities
{
    public class RootMenu : AuditableEntity<long>
    {
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
