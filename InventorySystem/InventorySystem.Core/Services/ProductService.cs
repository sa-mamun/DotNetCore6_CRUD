using InventorySystem.Core.Entities;
using InventorySystem.Core.UnitOfWorks;
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

        public void Dispose()
        {
            _productUnitOfWork?.Dispose();
        }
    }
}
