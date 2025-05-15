using Reqnroll;

[Binding]
public class Hooks
{
    [BeforeTestRun]
    public static void BeforeRun() => Console.WriteLine("Starting API Tests...");

    [AfterTestRun]
    public static void AfterRun() => Console.WriteLine("API Tests completed.");
}