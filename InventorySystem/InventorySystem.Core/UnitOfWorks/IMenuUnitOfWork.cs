using InventorySystem.Core.Repositories;
using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.UnitOfWorks
{
    public interface IMenuUnitOfWork : IUnitOfWork
    {
        public IMenuRepository MenuRepository { get; set; }
    }
}
