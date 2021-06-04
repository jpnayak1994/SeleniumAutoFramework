using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumAutoFramework.Base;
using SeleniumAutoFramework.Extensions;

namespace SeleniumAutoTest.Pages
{
   public  class HomePage:BasePage
    {
        //Initialize the home Page
        public HomePage(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig, loggingStep)
        {
        }
        //In the home page click Login link
        IWebElement lnklogin =>_parallelConfig.Driver.FindElement(By.LinkText("Login"));
        public LoginPage ClickLogin()
        {
            lnklogin.Click();
            return new LoginPage(_parallelConfig, loggingStep);
        }
        //Check If LogIn Link Exists
        internal void CheckIfLoginExist()
        {
            _parallelConfig.Driver.WaitForPageLoaded();
            lnklogin.AssertElementPresent();
        }
        IWebElement lnkLoggedInUser => _parallelConfig.Driver.FindElement(By.XPath("//a[@title='Manage']"));
       // public IWebElement lnkLogOff => DriverContext.Driver.FindElement(By.LinkText("Log off"));
        

        //In the home page click Employee List link
        IWebElement lnkEmployeeList => _parallelConfig.Driver.FindElement(By.LinkText("Employee List"));
        public EmployeeListPage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return new EmployeeListPage(_parallelConfig, loggingStep);
        }
        internal string GetLoggedInUser()
        {
            return lnkLoggedInUser.GetLinkText();
        }
      
    }
}
