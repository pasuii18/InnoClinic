using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Presentation.Common.Config;

public static class IdentityServerConfig
{
    public static IServiceCollection ConfigureIdentityServer
        (this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(config =>
        {
            config.Password.RequiredLength = 4;
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

        var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
        var filePath = Path.Combine(environment.ContentRootPath, "IS4_CERT.pfx");
        var certificate = new X509Certificate2(filePath, "kn1990svs"); // users-secrets?
        services.AddIdentityServer()
            .AddAspNetIdentity<IdentityUser>()
            .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
            .AddInMemoryApiResources(Configuration.GetApiResources())
            .AddInMemoryApiScopes(Configuration.GetApiScopes())
            .AddInMemoryClients(Configuration.GetClients())
            // .AddConfigurationStore(options =>
            // {
            //     options.ConfigureDbContext = b =>
            //         b.UseSqlServer(connectionString,
            //             sql => sql.MigrationsAssembly(migrationsAssembly));
            // })
            // .AddOperationalStore(options =>
            // {
            //     options.ConfigureDbContext = b =>
            //         b.UseSqlServer(connectionString,
            //             sql => sql.MigrationsAssembly(migrationsAssembly));
            //
            //     options.EnableTokenCleanup = true;
            // })
            .AddSigningCredential(certificate);
            // .AddDeveloperSigningCredential();

        return services;
    }
}