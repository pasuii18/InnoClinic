using System.Reflection;
using Application;
using Application.Interfaces.ServicesInterfaces;
using Application.Services;
using FluentValidation;
using Infrastructure;
using Presentation.Common.Middleware;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        builder.Services.AddApplication();
        
        var app = builder.Build();

        app.UseCustomExceptionsHandler();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}