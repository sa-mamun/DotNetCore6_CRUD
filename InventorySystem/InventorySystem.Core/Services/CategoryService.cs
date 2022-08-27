using InventorySystem.Core.Entities;
using InventorySystem.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryUnitOfWork _categoryUnitOfWork;

        public CategoryService(ICategoryUnitOfWork categoryUnitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
        }
        public void Create(Category category)
        {
            _categoryUnitOfWork.CategoryRepository.Add(category);
            _categoryUnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _categoryUnitOfWork?.Dispose();
        }
    }
}
