using InventorySystem.Core.Contexts;
using InventorySystem.Core.Entities;
using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Repositories
{
    public interface IProductCommandRepository : IBaseRepository<Product, long, CoreDbContext>
    {
        void GetProductById(long id);
    }
}
