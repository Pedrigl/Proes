using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Interfaces;
using ProesBack.Interfaces.Common;
using ProesBack.Services;
using System.Runtime.CompilerServices;

namespace ProesBack.Infrastructure.ExtensionMethods
{
    public static class CommonInjectDependence
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginViewModelService, LoginViewModelService>();
            services.AddTransient<IUserViewModelService, UserViewModelService>();
            services.AddTransient<ICourseViewModelService, CourseViewModelService>();
            services.AddTransient<IAssignmentViewModelService, AssignmentViewModelService>();
            services.AddTransient<IUserCourseViewModelService, UserCourseViewModelService>();
            
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IAssignmentRepository, AssignmentRepository>();
            services.AddTransient<IUserCoursesRepository, UserCourseRepository>();
            return services;
        }
    }
}
