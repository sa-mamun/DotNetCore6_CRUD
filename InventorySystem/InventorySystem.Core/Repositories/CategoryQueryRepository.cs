using Dapper;
using InventorySystem.Core.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Repositories
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly DbConnection _dbConnection;
        public CategoryQueryRepository(CoreDbContext dbContext)
        {
            _dbConnection = dbContext.Database.GetDbConnection();
        }

        public List<CategoryDto> LoadCategories()
        {
            using (var con = new SqlConnection(_dbConnection.ConnectionString))
            {
                con.Open();
                var result = con.Query<CategoryDto>(@"SELECT Id, Name FROM Categories");
                var result2 = con.Query<CategoryDto>(@"SELECT Id, Name FROM Categories");

                return result.ToList();
            };
        }
    }
}
