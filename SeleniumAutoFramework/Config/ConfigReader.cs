using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.XPath;
using System.Xml;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SeleniumAutoFramework.Config
{
    public static class ConfigReader
    {
        
        public static void SetFrameworkSettings()
        {
            //// with GlobalConfig.xml
            //XPathItem AUT;
            ////XPathItem Browser;
            //XPathItem TestType;
            //XPathItem IsLog;
            //XPathItem LogPath;
            //XPathItem BuildName;
            ////XPathItem UserName;
            //XPathItem Technology;
            //XPathItem IsReport;
            ////Reading the XML file
            //string strfileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            ////Open the file and read the data
            //FileStream stream = new FileStream(strfileName, FileMode.Open);
            //XPathDocument document = new XPathDocument(stream);
            //XPathNavigator navigator = document.CreateNavigator();

            //AUT = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/AUT");
            //BuildName = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/BuildName");
            //TestType = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/TestType");
            //IsLog = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/IsLog");
            //IsReport = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/IsReport");
            //LogPath = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/LogPath");

            ////Browser = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/Browser");
            ////IsLog = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/IsLog");
            ////UserName = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/UserName");
            //Technology = navigator.SelectSingleNode("SeleniumAutoFramework/RunSettings/Technology");
           


            //Settings.AUT = AUT.ToString();
            //Settings.BuildName = BuildName.ToString();
            //Settings.Testtype = TestType.ToString();
            //Settings.IsLog = IsLog.ToString();
            //Settings.IsReport = IsReport.ToString();
            //Settings.LogPath = LogPath.ToString();
            //Settings.Technology = Technology.ToString();


            ////With Configuration Setup
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();


            Settings.Config_AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT;
            Settings.Config_TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.Config_IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            //Settings.IsReporting = EATestConfiguration.EASettings.TestSettings["staging"].IsReadOnly;
            Settings.Config_LogPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            Settings.Config_AppConnectionString = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUTConnectionString;
            Settings.Config_BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
            // Settings.Config_Browser2Type = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser2;
            
            //Log
            Settings.Config_Login_excel_sheet = configurationRoot.GetSection("testSettings").Get<TestSettings>().Login_excel_sheet;
            Settings.Config_LogPathDirectory = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogDirectoryPath;
            Settings.Config_Login_excel_rowNo = configurationRoot.GetSection("testSettings").Get<TestSettings>().Login_excel_rowNo;

            //Emp Search
            Settings.Config_EmpSearch_sheet = configurationRoot.GetSection("testSettings").Get<TestSettings>().SearchEmpDirectory_sheet;
            Settings.Config_EmpSearch_Directory = configurationRoot.GetSection("testSettings").Get<TestSettings>().SearchEmpDirectoryPath;
            //Create Emp
            Settings.Config_CreateEmp_sheet = configurationRoot.GetSection("testSettings").Get<TestSettings>().CreateEmpDirectory_sheet;
            Settings.Config_CreateExtent_Directory = configurationRoot.GetSection("testSettings").Get<TestSettings>().CreateExtentDirectoryPath;
            //Extent Report
           // Settings.ExtentReportPathConfig = configurationRoot.GetSection("testSettings").Get<TestSettings>().ExtentReport_PathJson;

        }
    }
}
