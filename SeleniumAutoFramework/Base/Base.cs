using OpenQA.Selenium;
using SeleniumAutoFramework.Helpers;


namespace SeleniumAutoFramework.Base
{
   public class Base
    {
        // public IWebDriver Driver { get; set; }
        public readonly ParallelConfig _parallelConfig;
        public readonly LoggingStep loggingStep;
        public Base(ParallelConfig parallelConfig, LoggingStep loggingStep)
        {
            _parallelConfig = parallelConfig;
            this.loggingStep = loggingStep;
        }
        //To Check whether we are getting actual page or not
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
