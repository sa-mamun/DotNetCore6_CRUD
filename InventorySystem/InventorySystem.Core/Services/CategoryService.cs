using InventorySystem.Core.Entities;
using InventorySystem.Core.Repositories;
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
        ICategoryQueryRepository _categoryQueryRepository;
        IProductQueryRepository _productQueryRepository;

        public CategoryService(ICategoryUnitOfWork categoryUnitOfWork, ICategoryQueryRepository categoryQueryRepository, IProductQueryRepository productQueryRepository)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
            _categoryQueryRepository = categoryQueryRepository;
            _productQueryRepository = productQueryRepository;
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
        public List<CategoryDto> LoadAll() => _categoryQueryRepository.LoadCategories();

        public void Dispose()
        {
            _categoryUnitOfWork?.Dispose();
        }

    }
}
