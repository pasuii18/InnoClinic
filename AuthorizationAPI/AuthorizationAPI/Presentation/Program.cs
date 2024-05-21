using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Presentation.Common.Config;
using Presentation.Common.Middleware;

namespace Presentation;

public class Program()
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.ConfigureCors();
        builder.Services.ConfigureIdentityServer(builder.Environment);

        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                DbInitializer.InitializeDb(context);
                DbInitializer.InitializeData(context, userManager);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        app.UseCors("AllowSpecificOrigin");
        app.UseIdentityServer();

        app.UseCustomExceptionsHandler();
        app.UseHttpsRedirection();
        app.MapDefaultControllerRoute();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}