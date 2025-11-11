using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Repositories.DataContext;
using task.core.Interfaces.Services;
using task.infraestructure.Repositories;
using task.infraestructure.Repositories.DataContext;
using task.infraestructure.Services;

namespace task.Infrastructure.Repository.DependencyInversion
{
    public static class ServicesExtensionsRepository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<IDataContext, DataContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITaskStatusRepository, TaskStatusRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();


            return services;
        }
    }
}
