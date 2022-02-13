using Task1.Domain.Interfaces.Base;
using Task1.Infrastructure.Base;
using Task1.Infrastructure.Context;

namespace Task1.API.Configuration;
    public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        #region Base & Repositories

        services.AddScoped<Task1DbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //services.AddScoped<IProductRepository, ProductRepository>();
        //services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

        #endregion

        #region Services

        //services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<IProductCategoryService, ProductCategoryService>();

        #endregion

        //#region Validators

        //services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
        //services.AddTransient<IValidator<ProductEditDto>, ProductEditValidator>();

        //services.AddTransient<IValidator<ProductCategoryAddDto>, ProductCategoryAddValidator>();
        //services.AddTransient<IValidator<ProductCategoryEditDto>, ProductCategoryEditValidator>();

        //#endregion

        return services;
    }
}