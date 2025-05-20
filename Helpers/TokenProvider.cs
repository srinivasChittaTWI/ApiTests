using Newtonsoft.Json;

namespace ApiTests.Helpers;

public static class TokenProvider
{
    private static string _cachedToken;

    public static async Task<string> GetTokenAsync()
    {
        if (!string.IsNullOrEmpty(_cachedToken))
            return _cachedToken;

        HttpClientFactory _client = new();
        var authData = ConfigManager.GetSection("AuthSettings");
        var body = new FormUrlEncodedContent([
            new KeyValuePair<string, string?>("client_id", authData["ClientId"]),
            new KeyValuePair<string, string?>("client_secret", authData["ClientSecret"]),
            new KeyValuePair<string, string?>("grant_type", "client_credentials")
        ]);

        var response = await _client.PostAsync(authData["TokenURL"], body);
        var tokenJson = await response?.Content.ReadAsStringAsync()!;
        dynamic tokenObj = JsonConvert.DeserializeObject(tokenJson) ?? throw new InvalidOperationException();
        _cachedToken = tokenObj.access_token;
        return _cachedToken;
    }
}