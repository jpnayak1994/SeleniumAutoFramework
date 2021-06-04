using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }
        public BrowserType Type { get; set; }
    }
        public enum BrowserType
        {
            Chrome,
            internetExplorer,
            Firefox
        }
    
}
