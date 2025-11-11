using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using task.core.Interfaces.UseCases;
using task.Infrastructure.UseCases;
using task.Infrastructure.UseCases.Authentication;

namespace task.infraestructure.UseCase.DependencyInversionUseCase
{
    public static class ServicesExtensionsUseCase
    {
        public static IServiceCollection AddUseCase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<IUserUseCase, UserUseCase>();
            services.AddTransient<IAuthenticationUseCase, AuthenticationUseCase>();
            services.AddTransient<ITaskStatusUseCase, TaskStatusUseCase>();
            services.AddTransient<ITaskUseCase, TaskUseCase>();


            return services;
        }
    }
}
