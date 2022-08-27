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
    public class CategoryRepository : BaseRepository<Category, long, CoreDbContext>, ICategoryRepository
    {
        public CategoryRepository(CoreDbContext dbContext) 
            : base(dbContext)
        {
        }

        public void GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
