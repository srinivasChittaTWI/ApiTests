using Microsoft.Extensions.Configuration;

namespace ApiTests.Helpers;

public static class ConfigManager
{
    private static readonly IConfigurationRoot _config;
    private static readonly string env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "prod";

    static ConfigManager()
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // or AppContext.BaseDirectory
            .AddJsonFile("testsettings.json", false, true)
            .AddJsonFile($"testsettings.{env}.json", true, true)
            .AddEnvironmentVariables()
            .Build();
    }

    public static IConfigurationSection GetSection(string sectionName)
    {
        return _config.GetSection(sectionName);
    }

    public static string GetValue(string key)
    {
        return _config[key]!;
    }
}