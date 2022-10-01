using Autofac;
using InventorySystem.Core.Contexts;
using InventorySystem.Core.Repositories;
using InventorySystem.Core.Services;
using InventorySystem.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public CoreModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoreDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CoreDbContext>().As<ICoreDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryCommandRepository>().As<ICategoryCommandRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryQueryRepository>().As<ICategoryQueryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryUnitOfWork>().As<ICategoryUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductCommandRepository>().As<IProductCommandRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductQueryRepository>().As<IProductQueryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductUnitOfWork>().As<IProductUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MenuRepository>().As<IMenuRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MenuUnitOfWork>().As<IMenuUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<PlatformUnitOfWork>().As<IPlatformUnitOfWork>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
