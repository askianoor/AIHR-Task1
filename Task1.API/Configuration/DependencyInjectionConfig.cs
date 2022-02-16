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

        services.AddTransient<Task1DbContext>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient(typeof(IApplicationService<,,,,>), typeof(ApplicationService<,,,,>));
        
        #endregion

        #region Repositories

        services.AddTransient<ICourseRepository, CourseRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ITutorRepository, TutorRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserRequestRepository, UserRequestRepository>();
        services.AddTransient<IUserRequestCourseRepository, UserRequestCourseRepository>();

        #endregion

        #region Services

        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<ITutorService, TutorService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserRequestService, UserRequestService>();
        services.AddTransient<IUserRequestCourseService, UserRequestCourseService>();

        #endregion

        return services;
    }
}