using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Services;
using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace LiteratureProject.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILiteratureWorkService,LiteratureWorkService>();
            services.AddScoped<IBulgarianService, BulgarianService>();
            services.AddScoped<ITestingService, TestingService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddSingleton<GCSService>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                string credentialsPath = config["GoogleCloud:CredentialsFilePath"];
                string bucketName = config["GoogleCloud:BucketName"];
                return new GCSService(credentialsPath, bucketName);
            });
            return services;
        }
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
            }
            )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
