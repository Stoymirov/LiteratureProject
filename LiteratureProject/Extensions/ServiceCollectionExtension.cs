using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace LiteratureProject.Extensions
{
    public static class ServiceCollectionExtension
    {
        //public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        //{
        //    services.AddScoped<IHouseService, HouseService>();
        //    services.AddScoped<IAgentService, AgentService>();
        //    services.AddScoped<IStatisticService, StatisticService>();
        //    services.AddScoped<IRepository, Repository>();
        //    return services;
        //}
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();


            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
