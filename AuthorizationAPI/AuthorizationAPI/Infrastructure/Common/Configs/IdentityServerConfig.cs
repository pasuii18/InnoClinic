using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Configs;

public static class IdentityServerConfig
{
    public static IServiceCollection ConfigureIdentityServer
        (this IServiceCollection services, 
            IWebHostEnvironment environment,
            string connectionString)
    {
        services.AddIdentity<User, IdentityRole>(config =>
        {
            config.Password.RequiredLength = 6;
            config.Password.RequireDigit = false;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "IdentityServer.Cookie";
            config.LoginPath = "/Auth/Login";
            config.LogoutPath = "/Auth/Logout";
        });

        var migrationsAssembly = typeof(IdentityServerConfig).GetTypeInfo().Assembly.GetName().Name;
        var filePath = Path.Combine(environment.ContentRootPath, "IS4_CERT.pfx");
        var certificate = new X509Certificate2(filePath, "kn1990svs"); // users-secrets?
        services.AddIdentityServer()
            .AddAspNetIdentity<User>()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
            
                options.EnableTokenCleanup = true;
            })
            .AddSigningCredential(certificate);
            // .AddDeveloperSigningCredential();

        return services;
    }
}