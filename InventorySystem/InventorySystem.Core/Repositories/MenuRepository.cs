﻿using InventorySystem.Core.Contexts;
using InventorySystem.Core.Entities;
using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Repositories
{
    public class MenuRepository : BaseRepository<Menu, long, CoreDbContext>, IMenuRepository
    {
        public MenuRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
