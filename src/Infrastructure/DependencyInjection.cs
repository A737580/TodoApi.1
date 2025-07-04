using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Application.Common.Interfaces;
using TodoApi.Infrastructure.Data;

namespace TodoApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}