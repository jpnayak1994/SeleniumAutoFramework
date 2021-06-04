using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumAutoFramework.Base;
using SeleniumAutoFramework.Config;
using SeleniumAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

//Same parallel
//[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SeleniumAutoTest.Hook
{
    [Binding]
    public  class Hooks:TestInitializeHook
    {
        //private DriverContext _driver;
        //string fileName;
       // ExcelHelper excelHelper;
        //public Hooks(DriverContext driver) : base(Settings.Config_BrowserType, driver)
        //{
        //    _driver = driver;
        //}
        private readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;
        private readonly LoggingStep loggingStep;
        //public Hooks(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //    //ConfigReader.SetFrameworkSettings();
        //    _parallelConfig1 = parallelConfig;
        //}
        public Hooks(LoggingStep loggingStep,ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig, loggingStep)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            this.loggingStep = loggingStep;
        }
        private static ExtentTest featureName;
        [AfterStep]
        public void AfterEachStep()
        {

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                //screenshot in the Base64 format
                var mediaEntity = _parallelConfig.CaptureScreenshotAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }
        [BeforeTestRun]
        public static void BeforeTestRunMethod()
        {
            ConfigReader.SetFrameworkSettings();
            TestInitalize();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //ConfigReader.SetFrameworkSettings();
            //Get feature Name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Create dynamic scenario name
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            //Initialize all
            loggingStep.FeatureFileName = _featureContext.FeatureInfo.Title;
            // logHelpers = new LogHelpers();
            LogHelpers.LogFile(loggingStep.FeatureFileName, "Feature Name is Set");
            InitializeSettings();

           

            //Set up Excel file
            //excelHelper = new ExcelHelper();
            //fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            //ExcelHelper.PopulateInCollection(fileName);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Once the scenario is completed, then we can close the browser
            _parallelConfig.Driver.Quit();
            //for (int i = 0; i < 2; i++)
            //{
            //    BeforeTestRunMethod();
            //}
        }
        [AfterTestRun, OneTimeTearDown]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();

        }
    }
}
