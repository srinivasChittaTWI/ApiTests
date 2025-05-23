﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
using Reqnroll;
namespace ApiTests.Features
{
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserLoginFeature : object, Xunit.IClassFixture<UserLoginFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new global::System.Globalization.CultureInfo("en-US"), "Features", "User Login", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "sampleTest.feature"
#line hidden
        
        public UserLoginFeature(UserLoginFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async global::System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async global::System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async global::System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            try
            {
                if (((testRunner.FeatureContext != null) 
                            && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
                {
                    await testRunner.OnFeatureEndAsync();
                }
            }
            finally
            {
                if (((testRunner.FeatureContext != null) 
                            && testRunner.FeatureContext.BeforeFeatureHookFailed))
                {
                    throw new global::Reqnroll.ReqnrollException("Scenario skipped because of previous before feature hook error");
                }
                if ((testRunner.FeatureContext == null))
                {
                    await testRunner.OnFeatureStartAsync(featureInfo);
                }
            }
        }
        
        public async global::System.Threading.Tasks.Task TestTearDownAsync()
        {
            if ((testRunner == null))
            {
                return;
            }
            try
            {
                await testRunner.OnScenarioEndAsync();
            }
            finally
            {
                global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
                testRunner = null;
            }
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async global::System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async global::System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async global::System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            try
            {
                await this.TestInitializeAsync();
            }
            catch (System.Exception e1)
            {
                try
                {
                    ((Xunit.IAsyncLifetime)(this)).DisposeAsync();
                }
                catch (System.Exception e2)
                {
                    throw new System.AggregateException("Test initialization failed", e1, e2);
                }
                throw;
            }
        }
        
        async global::System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Valid login")]
        [Xunit.TraitAttribute("FeatureTitle", "User Login")]
        [Xunit.TraitAttribute("Description", "Valid login")]
        [Xunit.TraitAttribute("Category", "API")]
        [Xunit.TraitAttribute("Category", "LOGIN")]
        [Xunit.TraitAttribute("Category", "owner:feeds")]
        [Xunit.TraitAttribute("Category", "critical")]
        public async global::System.Threading.Tasks.Task ValidLogin()
        {
            string[] tagsOfScenario = new string[] {
                    "API",
                    "LOGIN",
                    "owner:feeds",
                    "critical"};
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Valid login", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 9
        await testRunner.GivenAsync("I have a valid login payload", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 10
        await testRunner.WhenAsync("I send a POST request to \"/login\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 11
        await testRunner.ThenAsync("the response code should be 200", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async global::System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await UserLoginFeature.FeatureSetupAsync();
            }
            
            async global::System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await UserLoginFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
