using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Infrastructure.Common.Configs;

public class LoggerConfig
{
    public static void ConfigureLogger(
        IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        
       Log.Logger.Write(LogEventLevel.Information, "OfficeAPI service started!");
    }
}