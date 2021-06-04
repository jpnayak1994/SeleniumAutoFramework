using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using SeleniumAutoFramework;
using SeleniumAutoFramework.Extensions;
using SeleniumAutoFramework.Base;

namespace SeleniumAutoTest.Pages
{
    public class LoginPage:BasePage
    {
        //Initialize LoginPage
        public LoginPage(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig,loggingStep)
        {
        }
        // IWebElement UserName => _driver.FindElement(By.Id("UserName"));
        IWebElement UserName => _parallelConfig.Driver.FindElement(By.Id("UserName"));
        IWebElement Password => _parallelConfig.Driver.FindElement(By.Id("Password"));
        IWebElement LoginButton => _parallelConfig.Driver.FindElement(By.CssSelector(".btn-default"));

        public void EnterUserNameAndPassWord(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
        }
        public HomePage ClickLogin()
        {
            LoginButton.Submit();
            return new HomePage(_parallelConfig, loggingStep);
        }

        internal void CheckIfLoginExists()
        {
            
            UserName.AssertElementPresent();
        }
    }
}
