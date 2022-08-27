using InventorySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Core.Contexts;

public class CoreDbContext : DbContext, ICoreDbContext
{
    private readonly string _connectionString;
    private readonly string _migrationAssemblyName;

    public CoreDbContext(string connectionString, string migrationAssemblyName)
    {
        _connectionString = connectionString;
        _migrationAssemblyName = migrationAssemblyName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        if (!dbContextOptionsBuilder.IsConfigured)
        {
            dbContextOptionsBuilder.UseSqlServer(
                _connectionString,
                m => m.MigrationsAssembly(_migrationAssemblyName));
        }

        base.OnConfiguring(dbContextOptionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
            //.OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Product>()
        //    .WithOne(c => c.Comment)
        //    .HasForeignKey(v => v.CommentId)
        //    .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}

