using OpenQA.Selenium;
using SeleniumAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoTest.Pages
{
    public class EmployeeListPage:BasePage
    {
        //Initialize LoginPage
        public EmployeeListPage(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig, loggingStep)
        {
        }
        //In the Employee page 
        IWebElement lnkCreateNew => _parallelConfig.Driver.FindElement(By.LinkText("Create New"));
         public IWebElement lnkLogOff => _parallelConfig.Driver.FindElement(By.LinkText("Log off"));
        public bool logoffExist() => lnkLogOff.Displayed;
        public CreateEmployeePage ClickCreateNew()
        {
            lnkCreateNew.Click();
            return new CreateEmployeePage(_parallelConfig, loggingStep);
        }
         IWebElement txtsearch => _parallelConfig.Driver.FindElement(By.Name("searchTerm"));
        public void EnterNameForSearch(string searchtxt)
        {
            txtsearch.SendKeys(searchtxt);
        }
        IWebElement lnkSearch => _parallelConfig.Driver.FindElement(By.CssSelector(".btn-default"));
        public void ClickSearch()
        {
            lnkSearch.Submit();
        }
        public void ClickLogOff()
        {
            lnkLogOff.Click();
            //return GetInstance<HomePage>();
        }
    }
}
