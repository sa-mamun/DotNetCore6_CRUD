using InventorySystem.Core.Contexts;
using InventorySystem.Core.Repositories;
using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.UnitOfWorks
{
    public class MenuUnitOfWork : UnitOfWork, IMenuUnitOfWork
    {
        public IMenuRepository MenuRepository { get; set; }

        public MenuUnitOfWork(
            CoreDbContext dbContext,
            IMenuRepository menuRepository) 
            : base(dbContext)
        {
            MenuRepository = menuRepository;
        }
    }
}
