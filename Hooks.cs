using Reqnroll;

[Binding]
public class Hooks
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        Console.WriteLine($"-- Starting Scenario: {ScenarioContext.Current.ScenarioInfo.Title}");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("-- Finished Scenario");
    }
}