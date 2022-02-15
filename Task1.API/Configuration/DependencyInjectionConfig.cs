using Microsoft.EntityFrameworkCore;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Services;
using Task1.Infrastructure.Base;
using Task1.Infrastructure.Context;
using Task1.Infrastructure.Repositories;

namespace Task1.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {

        #region Base

        services.AddScoped<Task1DbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion

        #region Repositories

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITutorRepository, TutorRepository>();

        #endregion

        #region Services

        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<ITutorService, TutorService>();

        #endregion
        
        return services;
    }
}