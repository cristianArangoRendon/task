using Microsoft.Extensions.DependencyInjection;
using task.core.Interfaces.Services;
using task.Infrastructure.Services;
using WMSGlobal.Infrastructure.Services;

namespace task.infraestructure.Services.DependencyInversionService
{
    public static class ServicesExtensionsService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ILogService, LogsService>();
            services.AddTransient<ISqlCommandService, SqlCommandService>();
            services.AddTransient<IExecuteStoreProcedureService, ExecuteStoreProcedureService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ISecurityService, SecurityService>();

            return services;
        }
    }
}
