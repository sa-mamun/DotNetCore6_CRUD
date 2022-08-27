﻿using InventorySystem.Core.Contexts;
using InventorySystem.Core.Repositories;
using InventorySystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.UnitOfWorks;

public class CategoryUnitOfWork : UnitOfWork, ICategoryUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; set; }

    public CategoryUnitOfWork(CoreDbContext dbContext,
        ICategoryRepository categoryRepository) : base(dbContext)
    {
        CategoryRepository = categoryRepository;
    }
}
