using InventorySystem.Core.Contexts;
using InventorySystem.Core.Entities;
using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Repositories;

public class ProductCommandRepository : BaseRepository<Product, long, CoreDbContext>, IProductCommandRepository
{
    public ProductCommandRepository(CoreDbContext dbContext)
        : base(dbContext)
    {
    }

    public void GetProductById(long id)
    {
        throw new NotImplementedException();
    }
}
