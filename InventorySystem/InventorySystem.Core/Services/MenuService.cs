using InventorySystem.Core.Entities;
using InventorySystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Services
{
    public class MenuService : IMenuService
    {
        IMenuRepository _menuRepository;

        public MenuService()
        {
            _menuRepository = new MenuRepository();    
        }

        public IList<Menu> LoadAllMenus()
        {
            
        }
    }
}
