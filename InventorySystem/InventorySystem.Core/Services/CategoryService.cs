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

        public void Update(Category category)
        {
            var oldCategory = _categoryUnitOfWork.CategoryRepository.GetFirstOrDefault(x => x, x => x.Id == 2);
            if (oldCategory != null)
            {
                oldCategory.Name = category.Name;
                _categoryUnitOfWork.CategoryRepository.Update(oldCategory);
                _categoryUnitOfWork.SaveChanges();
            }
        }

        public void Dispose()
        {
            _categoryUnitOfWork?.Dispose();
        }
    }
}
