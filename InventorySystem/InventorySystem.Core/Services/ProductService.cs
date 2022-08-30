using InventorySystem.Core.Entities;
using InventorySystem.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Services
{
    public class ProductService : IProductService
    {
        IProductUnitOfWork _productUnitOfWork { get; set; }
        public ProductService(IProductUnitOfWork productUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
        }

        public void Create(Product product)
        {
            _productUnitOfWork.ProductRepository.Add(product);
            _productUnitOfWork.SaveChanges();
        }

        public void Update(Product product)
        {
            var oldProduct = _productUnitOfWork.ProductRepository.GetFirstOrDefault(x => x, x => x.Id == 1, x => x.Include(i => i.Category), true);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                _productUnitOfWork.ProductRepository.Update(oldProduct);
                _productUnitOfWork.SaveChanges();
            }
        }

        public void Dispose()
        {
            _productUnitOfWork?.Dispose();
        }
    }
}
