using ServicesAPI.Common;

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