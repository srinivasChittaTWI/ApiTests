using Allure.Net.Commons;
using ApiTests.Helpers;
using Reqnroll;
using Serilog;
using Xunit;

namespace ApiTests.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly HttpClientFactory _apiClient = new();
    private object? _payload;
    private HttpResponseMessage? _response;
    //private static ILogger _logger => LoggerUtil.Logger;
    

    [Given(@"I have a valid login payload")]
    public void GivenIHaveAValidLoginPayload()
    {
        AllureApi.SetTestName("Open labels page");
        _payload = new { username = "admin", password = "secret" };
       // _logger.Information("Starting given login payload");
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