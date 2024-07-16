using Microsoft.Extensions.DependencyInjection;
using Northwind.Categories.Application.Contracts;
using Northwind.Categories.Domain.Interface;
using Northwind.Categories.Persistence.Repository;
using Northwind.Categories.Service;

namespace Northwind.Categories.IOC.Dependency
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            #region "Servicios"
            services.AddTransient<ICategoryService, CategoryService>();
            #endregion
        }
    }
}
