using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ApiTests.Helpers;

public class LoggerUtil
{
    private static readonly LoggingLevelSwitch _levelSwitch = new();
    private static ILogger _logger;
    private static bool _isInitialized;

    public static ILogger Logger => _logger ?? InitializeLogger();

    private static ILogger InitializeLogger()
    {
        if (_isInitialized)
            return _logger;

        // Setup configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("testsettings.json", optional: true, reloadOnChange: true)
            .Build();

        // Set default log level from config or use Information as default
        var logLevelString = configuration.GetSection("Serilog:MinimumLevel:Default").Value ?? "Information";
        if (Enum.TryParse<LogEventLevel>(logLevelString, out var logLevel))
            _levelSwitch.MinimumLevel = logLevel;
        else
            _levelSwitch.MinimumLevel = LogEventLevel.Information;

        // File path for logs
        var logFilePath = configuration.GetSection("Serilog:WriteTo:0:Args:path").Value ?? "logs/reqnroll-tests-.log";

        // Create logger
        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Application", "Reqnroll.Tests")
            .MinimumLevel.ControlledBy(_levelSwitch)
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                logFilePath,
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        _isInitialized = true;
        return _logger;
    }

    /*
    public static void SetLogLevel(LogEventLevel level)
    {
        _levelSwitch.MinimumLevel = level;
        Logger.Information($"Log level set to {level}");
    }
    */

    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }
}