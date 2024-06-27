using Application;
using Infrastructure;
using Infrastructure.Common.Options;
using ServicesAPI.Common;
using ServicesAPI.Common.Middlewares;

namespace ServicesAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        await WebApplication
            .CreateBuilder(args)
            .BuilderConfigure()
            .Build()
            .ApplicationConfigure()
            .RunApplicationAsync();
    }
}