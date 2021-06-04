using SeleniumAutoFramework.Base;
using SeleniumAutoFramework.Config;
using SeleniumAutoFramework.Helpers;
using SeleniumAutoTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutoTest.Steps
{
    [Binding]
    public class ExtendedSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig1;
        private readonly LoggingStep _loggingStep;
        public ExtendedSteps(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig, loggingStep)
        {
            _parallelConfig1 = parallelConfig;
            _loggingStep = loggingStep;
        }
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            // ScenarioContext.Current.Pending();
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.Config_AUT);
            LogHelpers.LogFile(_loggingStep.FeatureFileName, "Navigated");
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig, _loggingStep);
        }
        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            // ScenarioContext.Current.Pending();
            _parallelConfig.CurrentPage.As<HomePage>().CheckIfLoginExist();
            LogHelpers.LogFile(_loggingStep.FeatureFileName, "I see application opened");
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string LinkName)
        {
            if (LinkName == "login")
            {
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickLogin();
                LogHelpers.LogFile(_loggingStep.FeatureFileName, "login link");
                //Now CurrentPage=LoginPage
            }
            else if (LinkName == "employeeList")
            {
                //CurrentPage = GetInstance<HomePage>();
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickEmployeeList();
                LogHelpers.LogFile(_loggingStep.FeatureFileName, "employeeList opened");
                //Now CurrentPage=EmployeeListPage
            }
            else if (LinkName == "LogOff")
            {
                _parallelConfig.CurrentPage = new EmployeeListPage(_parallelConfig, _loggingStep); //GetInstance<EmployeeListPage>();
                _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickLogOff();
                LogHelpers.LogFile(_loggingStep.FeatureFileName, "logoff link");
                //if(employeeListPage== null)
                //{
                //    employeeListPage = new EmployeeListPage(_driverHelper.Driver);
                //}
                //employeeListPage.ClickLogOff();
                //Now CurrentPage=LoginPage
            }
        }
        [Then(@"I click (.*) Button")]
        public void ThenIClickButton(string buttonName)
        {
            //if (buttonName == "Login")
            //{
            //    homePage = loginPage.ClickLogin();
            //    //Now CurrentPage=HomePage
            //}
            //else if (buttonName == "createnew")
            //{
            //    createEmployeePage = employeeListPage.ClickCreateNew();
            //    //Now CurrentPage=CreateEmployeePage
            //}
            //else if (buttonName == "create")
            //{
            //    employeeListPage = createEmployeePage.ClickCreateButton();
            //    //Now CurrentPage=employeeListPage
            //}
            if (buttonName == "Login")
            {
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<LoginPage>().ClickLogin();
                //Now CurrentPage=HomePage
            }
            else if (buttonName == "createnew")
            {
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickCreateNew();
                //Now CurrentPage=CreateEmployeePage
            }
            else if (buttonName == "create")
            {
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
                //Now CurrentPage=CreateEmployeePage
            }

        }
    }
}
    
