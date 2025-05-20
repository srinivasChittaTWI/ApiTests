using Microsoft.Extensions.Configuration;

public static class ConfigManager
{
    private static IConfigurationRoot _config;

    static ConfigManager()
    {
        
        _config = new ConfigurationBuilder()
            .AddJsonFile("testsettings.json")
            .Build();
    }

    public static string get(string key) => _config[key];
}