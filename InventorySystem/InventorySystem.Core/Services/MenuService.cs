using InventorySystem.Core.Entities;
using InventorySystem.Core.Repositories;
using InventorySystem.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuUnitOfWork _menuUnitOfWork;

        public MenuService(IMenuUnitOfWork menuUnitOfWork)
        {
            _menuUnitOfWork = menuUnitOfWork;
        }

        public IList<Menu> LoadAllMenus()
        {
            var data = _menuUnitOfWork.MenuRepository.Get<Menu>(x => x, null, null, null, true).ToList();
            return data;
        }
    }
}
