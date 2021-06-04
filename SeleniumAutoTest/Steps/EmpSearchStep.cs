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
   public  class EmpSearchStep:BaseStep
    {
        private readonly ParallelConfig _parallelConfig1;
        ExcelHelpers excelHelper;
        string fileName=null;
        static DataTableCollection dataCollection;
        private static List<DataCollection> _dataEmp = new List<DataCollection>();
        private readonly LoggingStep _loggingStep;
        public EmpSearchStep(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig, loggingStep)
        {
            _parallelConfig1 = parallelConfig;
            _loggingStep = loggingStep;
            excelHelper = new ExcelHelpers();
            fileName = Environment.CurrentDirectory.ToString() + Settings.Config_LogPathDirectory;
            dataCollection = excelHelper.ExcelToDataTable(fileName);
            _dataEmp = excelHelper.PopulateInCollection(fileName, "CreateDetails", dataCollection);

        }
        //[Then(@"I click createnew Button")]
        //public void ThenIClickCreatenewButton()
        //{
        //   // ScenarioContext.Current.Pending();
        //}

        [Then(@"I enter following details")]
        public void ThenIEnterFollowingDetails()
        {
            _parallelConfig.CurrentPage.As<CreateEmployeePage>().CreateEmployee(excelHelper.ReadData("Name", _dataEmp), excelHelper.ReadData("Salary", _dataEmp), excelHelper.ReadData("DurationWorked", _dataEmp), excelHelper.ReadData("Grade", _dataEmp), excelHelper.ReadData("Email", _dataEmp));
            LogHelpers.LogFile(_loggingStep.FeatureFileName, "I enter following details");

            //ScenarioContext.Current.Pending();
        }

        //[Then(@"I click create Button")]
        //public void ThenIClickCreateButton()
        //{
        //   // ScenarioContext.Current.Pending();
        //}

    }
}
