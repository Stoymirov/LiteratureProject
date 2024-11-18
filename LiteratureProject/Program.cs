using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models;
using LiteratureProject.Infrastructure.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LiteratureProject.Extensions;
using HouseRentingSystem.Infrastructure.Data.SeedDb;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddApplicationServices();
SeedData data = new SeedData();
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("TeacherOnly", policy => policy.RequireClaim("TeacherName"));
//});
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRolesAsync(services); // Seed roles

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string adminEmail = "admin@example.com";
    string adminPassword = "Admin123!";
    string adminRole = "Admin";

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        // Create admin user if it doesn't exist
        adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
        var createResult = await userManager.CreateAsync(adminUser, adminPassword);

        if (createResult.Succeeded)
        {
            // Assign the Admin role to the user
            await userManager.AddToRoleAsync(adminUser, adminRole);
        }

    }
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error/500");
        app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();
}
