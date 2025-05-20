using Reqnroll;
using System.Net.Http.Json;
using ApiTests.Helpers;

[Binding]
public class LoginSteps
{
    private readonly HttpClientFactory _apiClient = new();
    private HttpResponseMessage? _response;
    private object? _payload;

    [Given(@"I have a valid login payload")]
    public void GivenIHaveAValidLoginPayload()
    {
        _payload = new { username = "admin", password = "secret" };
    }

    [When(@"I send a POST request to ""(.*)""")]
    public async Task WhenISendAPostRequestTo(string endpoint)
    {

        _response = await _apiClient.PostAsync("", _payload);
    }

    [Then(@"the response code should be (\d+)")]
    public void ThenTheResponseCodeShouldBe(int expectedCode)
    {
        Assert.Equal(expectedCode, (int)_response.StatusCode);
    }
}