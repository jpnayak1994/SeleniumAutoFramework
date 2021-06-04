using SeleniumAutoFramework.Base;
using SeleniumAutoFramework.Config;
using SeleniumAutoFramework.Helpers;
using SeleniumAutoTest.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutoTest.Steps
{
    [Binding]
  public  class LogStep :BaseStep
    {
        private readonly ParallelConfig _parallelConfig1;
        private readonly LoggingStep _loggingStep;
        ExcelHelpers excelHelper;
        string fileName;
        static DataTableCollection dataCollection;
        private static List<DataCollection> _dataColLogin = new List<DataCollection>();
        //LogHelpers _loghelpers;
        //StreamWriter _streamw;
        public LogStep(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig, loggingStep)
        {
            _parallelConfig1 = parallelConfig;
            excelHelper = new ExcelHelpers();
            fileName = Environment.CurrentDirectory.ToString() + Settings.Config_LogPathDirectory;
            //_loghelpers = logHelpers;
            _loggingStep = loggingStep;
            excelHelper = new ExcelHelpers();
            fileName = Environment.CurrentDirectory.ToString() + Settings.Config_LogPathDirectory;
            dataCollection = excelHelper.ExcelToDataTable(fileName);
            _dataColLogin = excelHelper.PopulateInCollection(fileName, "LoginDetails", dataCollection);
        }
      

      
        //Login Test Feature
        [When(@"I enter UserName and Password and click Login")]
        public void WhenIEnterUserNameAndPasswordAndClickLogin()
        {

            _parallelConfig.CurrentPage.As<LoginPage>().EnterUserNameAndPassWord("admin", "password");
            LogHelpers.LogFile(_loggingStep.FeatureFileName, "I enter UserName and Password and click Login");
            //ScenarioContext.Current.Pending();
        }

        //LoginTestRowsFeature
        [When(@"I enter UserName and Password as per (.*) provided and clicked Login")]
        public void WhenIEnterUserNameAndPasswordAsPerProvidedAndClickedLogin(string p0)
        {
            try
            {
                _parallelConfig.CurrentPage.As<LoginPage>().EnterUserNameAndPassWord(excelHelper.ReadDataUsingRowNo("UserName", _dataColLogin, p0), excelHelper.ReadDataUsingRowNo("Password", _dataColLogin, p0));

                LogHelpers.LogFile(_loggingStep.FeatureFileName, p0);
            }
            catch (Exception ex)
            {
                LogHelpers.LogFile(_loggingStep.FeatureFileName + "Error", ex.Message);
            }
            // _parallelConfig.CurrentPage.As<LoginPage>().EnterUserNameAndPassWord(excelHelper.ReadDataUsingRowNo("UserName", _dataColLogin, Convert.ToInt16(p0)), excelHelper.ReadDataUsingRowNo("Password", _dataColLogin,Convert.ToInt16(p0)));

        }


        [Then(@"I should see the Username with Hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            if (_parallelConfig.CurrentPage.As<HomePage>().GetLoggedInUser().Contains("admin"))
            {
                Console.WriteLine("Successfull Login!!!");
            }
            else
            {
                Console.WriteLine("UnSuccessfull Login!!!");
            }
        }

      

    }
}
