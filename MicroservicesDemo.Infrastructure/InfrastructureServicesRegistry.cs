using MicroservicesDemo.Application.Contracts.Infrastructure;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Infrastructure.Persistence;
using MicroservicesDemo.Infrastructure.Repositories;
using MicroservicesDemo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesDemo.Infrastructure
{
    public static class InfrastructureServicesRegistry
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UsersDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("UsersDb"), provider =>
                {
                    provider.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMessageProducer, RabbitMQProducer>();

            return services;
        }
    }
}
