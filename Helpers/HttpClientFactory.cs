using System.Text;
using System.Text.Json;

namespace ApiTests.Helpers;

public  class HttpClientFactory
{
    private readonly HttpClient _client;

    public HttpClientFactory()
    {
        _client = new HttpClient { BaseAddress = new Uri(ConfigManager.get("ApiBaseUrl")) };
    }
    
    public async Task<HttpResponseMessage> GetAsync(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);
        return response;
    }

    public async Task<HttpResponseMessage?> PostAsync<T>(string endpoint, T payload)
    {
        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(endpoint, content);
        return response;
    }

    public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T payload)
    {
        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync(endpoint, content);
        return response;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        var response = await _client.DeleteAsync(endpoint);
        return response;
    }
}