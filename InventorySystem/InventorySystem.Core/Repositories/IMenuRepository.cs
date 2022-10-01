using InventorySystem.Core.Contexts;
using InventorySystem.Core.Entities;
using InventorySystem.Data;

namespace InventorySystem.Core.Repositories
{
    public interface IMenuRepository : IBaseRepository<Menu, long, CoreDbContext>
    {

    }
}
