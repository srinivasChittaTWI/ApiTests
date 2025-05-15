using System.Net.Http.Headers;

public static class CustomHttpClientFactory
{
    public static HttpClient Create(string token = null)
    {
        var client = new HttpClient { BaseAddress = new Uri(ConfigManager.Get("ApiBaseUrl")) };
        if (!string.IsNullOrEmpty(token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return client;
    }
}