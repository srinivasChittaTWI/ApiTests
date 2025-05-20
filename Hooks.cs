using Allure.Net.Commons;
using Reqnroll;

namespace ApiTests;

[Binding]
public class Hooks
{
    [BeforeScenario("beforescenario")]
    public void BeforeScenario()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
        Console.WriteLine($"-- Starting Scenario: {ScenarioContext.Current.ScenarioInfo.Title}");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("-- Finished Scenario");
    }
}