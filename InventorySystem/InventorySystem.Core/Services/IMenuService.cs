using InventorySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Services
{
    public interface IMenuService
    {
        IList<Menu> LoadAllMenus();
    }
}
