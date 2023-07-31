﻿using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Infrastructure.Persistence;
using MicroservicesDemo.Infrastructure.Repositories;
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
                options.UseSqlServer(configuration.GetConnectionString("UsersDb"), provider =>
                {
                    provider.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
