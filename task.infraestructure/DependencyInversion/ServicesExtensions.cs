using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using task.infraestructure.Services.DependencyInversionService;
using task.infraestructure.UseCase.DependencyInversionUseCase;
using task.Infrastructure.Repository.DependencyInversion;

namespace task.infraestructure.DependencyInversion
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddRepositories(configuration);
            services.AddUseCase(configuration);
            services.AddServices();
            return services;
        }
    }
}
