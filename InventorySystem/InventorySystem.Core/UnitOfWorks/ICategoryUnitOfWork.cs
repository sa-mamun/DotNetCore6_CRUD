using InventorySystem.Core.Repositories;
using InventorySystem.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.UnitOfWorks
{
    public interface ICategoryUnitOfWork : IUnitOfWork
    {
        ICategoryCommandRepository CategoryRepository { get; set; }
    }
}
