using Infrastructure.Common.Options;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Infrastructure.Common.Configs;

public class LoggerConfig
{
    public static void ConfigureLogger(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        
        Log.Logger.Write(LogEventLevel.Information, "OfficeAPI service started!");

       // var optionsValue = options.Value;
       // var loggerConfig = new LoggerConfiguration()
       //     .MinimumLevel.Is(Enum.Parse<LogEventLevel>(optionsValue.MinimumLevel));
       //
       // foreach (var (source, level) in optionsValue.Override)
       // {
       //     loggerConfig.MinimumLevel.Override(source, Enum.Parse<LogEventLevel>(level));
       // }
       //
       // loggerConfig.WriteTo.MongoDB(cfg =>
       // {
       //     cfg.DatabaseUrl = optionsValue.DatabaseUrl;
       //     cfg.CollectionName = optionsValue.CollectionName;
       //     cfg.CappedMaxSizeMb = Convert.ToInt32(optionsValue.CappedMaxSizeMb);
       //     cfg.CappedMaxDocuments = Convert.ToInt32(optionsValue.CappedMaxDocuments);
       // });
       //
       // loggerConfig.CreateLogger();
       
    }
}