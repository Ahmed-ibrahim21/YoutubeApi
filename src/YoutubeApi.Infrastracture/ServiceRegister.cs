using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Domain.Abstraction;
using YoutubeApi.Infrastracture.Repositories;
using YoutubeApi.Infrastracture.UnitOfWorks;

namespace YoutubeApi.Infrastracture
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,IConfiguration config)
        {
           AddDbConnection(services, config);

            AddServicesToDiContainer(services);

            return services;
        }

        private static IServiceCollection AddDbConnection(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Database"));
            });

            return services;
        }


        private static IServiceCollection AddServicesToDiContainer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
