using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Repositories
{
    public interface ICategoryQueryRepository
    {
        List<CategoryDto> LoadCategories();
    }
}
