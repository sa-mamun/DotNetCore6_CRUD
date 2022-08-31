using InventorySystem.Core.Contexts;
using InventorySystem.Core.Repositories;
using InventorySystem.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.UnitOfWorks;

public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
{
    public IProductCommandRepository ProductRepository { get; set; }

    public ProductUnitOfWork(CoreDbContext dbContext,
        IProductCommandRepository productRepository) : base(dbContext)
    {
        ProductRepository = productRepository;
    }
}

