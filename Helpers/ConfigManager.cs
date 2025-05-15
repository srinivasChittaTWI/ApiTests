using Microsoft.Extensions.Configuration;

public static class ConfigManager
{
    private static IConfigurationRoot _config;

    static ConfigManager()
    {
        
        _config = new ConfigurationBuilder()
            .AddJsonFile("testsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }

    public static string Get(string key) => _config[key];
}