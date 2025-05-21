using Allure.Net.Commons;
using ApiTests.Helpers;
using Reqnroll;
using Serilog;

namespace ApiTests;

[Binding]
public class Hooks
{
        private static ILogger _logger => LoggerUtil.Logger;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _logger.Information("Starting test execution");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _logger.Information("Test execution complete"); 
            LoggerUtil.CloseAndFlush();
        }
        

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _logger.Information($"Starting feature: {featureContext.FeatureInfo.Title}");
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            _logger.Information($"Completed feature: {featureContext.FeatureInfo.Title}");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _logger.Information($"Starting scenario: {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var status = _scenarioContext.ScenarioExecutionStatus;
            if (status == ScenarioExecutionStatus.OK)
            {
                _logger.Information($"Scenario completed successfully: {_scenarioContext.ScenarioInfo.Title}");
            }
            else
            {
                // Log exception if available
                if (_scenarioContext.TestError != null)
                {
                    _logger.Error(_scenarioContext.TestError, 
                        $"Scenario failed: {_scenarioContext.ScenarioInfo.Title}");
                }
                else
                {
                    _logger.Error($"Scenario failed with status {status}: {_scenarioContext.ScenarioInfo.Title}");
                }
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo;
            _logger.Debug($"Executing step: {stepInfo.StepDefinitionType} {stepInfo.Text}");
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo;
            var stepResult = _scenarioContext.StepContext.Status;
            
            if (stepResult == ScenarioExecutionStatus.OK)
            {
                _logger.Debug($"Step executed successfully: {stepInfo.StepDefinitionType} {stepInfo.Text}");
            }
            else if (_scenarioContext.TestError != null)
            {
                _logger.Error(_scenarioContext.TestError, 
                    $"Step failed: {stepInfo.StepDefinitionType} {stepInfo.Text}");
            }
        }
}