using Application;
using Application.Services;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Common.Configs;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Presentation.Common.Middleware;

namespace Presentation;

public class Program()
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfrastructure(builder.Environment, builder.Configuration);

        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbInitializer.InitializeDb(context);
                DbInitializer.InitializeData(context, scope);
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