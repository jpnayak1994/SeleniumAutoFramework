
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumAutoFramework.Config;
using SeleniumAutoFramework.Helpers;
using System;
//using WebDriverManager;
using  SeleniumAutoFramework.Base;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;
//using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutoFramework.Base
{
    public  class TestInitializeHook: DriverContext
    {
        public readonly BrowserType _browser;
       private new readonly ParallelConfig _parallelConfig;
        private readonly LoggingStep _loggingStep;
        public static ExtentReports extent;
        public static ExtentKlovReporter klov;
        public ExtentTest test;
        private static string dateName = String.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        //public  LogHelpers logHelpers;
        //public string FeatureFileName = null;
        //public  StreamWriter _streamw;


        public TestInitializeHook(ParallelConfig parallelConfig,LoggingStep loggingStep) : base(parallelConfig,loggingStep)
        {
            
                ConfigReader.SetFrameworkSettings();
                _browser = Settings.Config_BrowserType;           
            _parallelConfig = parallelConfig;
            _loggingStep = loggingStep;
        }
        public void InitializeSettings()
        {
            

            //Open Browser
            OpenBrowser(_browser);
            //LogHelpers.Write("Navigated to the page!!!");
            // logHelpers.Write("Initialized the framework", _streamw);
            LogHelpers.LogFile(_loggingStep.FeatureFileName, "Initialized the framework");
        }
        public  void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    //driverContext.Driver = new ChromeDriver();
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("start-maximized");
                    option.AddArgument("--disable-gpu");
                    option.AddArgument("--headless");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _parallelConfig.Driver = new ChromeDriver(option);
                    browser = new Browser(_parallelConfig.Driver);
                    break;
                case BrowserType.internetExplorer:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    _parallelConfig.Driver = new InternetExplorerDriver(options);
                    browser = new Browser(_parallelConfig.Driver);
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions options1 = new FirefoxOptions();
                    options1.AddArgument("start-maximized");
                    options1.AddArgument("--disable-gpu");
                    /////option.AddArgument("--headless");
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _parallelConfig.Driver = new FirefoxDriver(options1);
                    browser = new Browser(_parallelConfig.Driver);
                    break;
                default:
                    ChromeOptions option2 = new ChromeOptions();
                    option2.AddArgument("start-maximized");
                    option2.AddArgument("--disable-gpu");
                    option2.AddArgument("--headless");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _parallelConfig.Driver = new ChromeDriver(option2);
                    browser = new Browser(_parallelConfig.Driver);
                    break;
            }
        }
        public static void TestInitalize()
        {
            //InitializeSettings();
            //Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);

            //Initialize Extent report before test starts
            //ConfigReader.SetFrameworkSettings();
            //   @"C:\Users\jyoti\source\repos\SeleniumCoding\Test06_01_2021\SeleniumAutoFramework\SeleniumAutoTest\ExtentReport.html"
          //  ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter(@"D:\SeleniumCodeUdemy\ExtentDetails\AutoReport"+ dateName + ".html");

               ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter(Settings.Config_CreateExtent_Directory + "AutReport" + dateName + ".html");
            //var htmlReporter = new ExtentHtmlReporter(@"C:\Users\jyoti\source\repos\SeleniumCoding\version8\SeleniumAutoFramework\SeleniumAutoTest\ExtentReport"+ dateName+ ".html");
            //C:\Users\jyoti\source\repos\SeleniumCoding\08_05_2021\SeleniumAutoFramework\SeleniumAutoTest
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            klov = new ExtentKlovReporter();

            //klov.InitMongoDbConnection("localhost", 27017);

            //klov.ProjectName = "ExecuteAutomation Test";

            //// URL of the KLOV server
            //klov.KlovUrl = "http://localhost:5689";

            //klov.ReportName = "Karthik KK" + DateTime.Now.ToString();


            extent.AttachReporter(htmlReporter);
        }

    }
}
