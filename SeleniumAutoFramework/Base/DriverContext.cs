using OpenQA.Selenium;
using SeleniumAutoFramework.Config;
using SeleniumAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoFramework.Base
{
   public  class DriverContext
    {
        public readonly ParallelConfig _parallelConfig;
        public readonly LoggingStep _loggingStep;
        public DriverContext(ParallelConfig parallelConfig, LoggingStep loggingStep)
        {
            _parallelConfig = parallelConfig;
            _loggingStep = loggingStep;
        }
        public void GoToUrl(string url)
        {
            _parallelConfig.Driver.Url = url;
        }
        public static Browser browser { get; set; }
        public void NavigateSite(IWebDriver driver)
        {
            _parallelConfig.Driver = driver;
            GoToUrl(Settings.Config_AUT);
            //LogHelpers.Write("Opened the Browser!!!");
        }
    }
}
