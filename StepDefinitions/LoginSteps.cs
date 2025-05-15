using Reqnroll;
using System.Net.Http.Json;

[Binding]
public class LoginSteps
{
    private HttpResponseMessage _response;
    private object _payload;

    [Given(@"I have a valid login payload")]
    public void GivenIHaveAValidLoginPayload()
    {
        _payload = new { username = "admin", password = "secret" };
    }

    [When(@"I send a POST request to ""(.*)""")]
    public async Task WhenISendAPOSTRequestTo(string endpoint)
    {
        var client = CustomHttpClientFactory.Create();
        _response = await client.PostAsJsonAsync(endpoint, _payload);
    }

    [Then(@"the response code should be (\d+)")]
    public void ThenTheResponseCodeShouldBe(int expectedCode)
    {
        Assert.Equal(expectedCode, (int)_response.StatusCode);
    }
}