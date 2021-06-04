using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  SeleniumAutoFramework.Base;

namespace SeleniumAutoFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }


        //[JsonProperty("browser1")]
        //public BrowserType Browser1 { get; set; }
        //[JsonProperty("browser2")]
        //public BrowserType Browser2 { get; set; }
        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }


        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("autConnectionString")]
        public string AUTConnectionString { get; set; }

        //Login
        [JsonProperty("login_excel_sheet")]
        public string Login_excel_sheet { get; set; }

        [JsonProperty("logDirectoryPath")]
        public string LogDirectoryPath { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }
        [JsonProperty("login_excel_rowNo")]
        public int Login_excel_rowNo { get; set; }

        //Emp Details For Insertion
        [JsonProperty("CreateEmpDirectory_sheet")]
        public string CreateEmpDirectory_sheet { get; set; }

        [JsonProperty("CreateExtentDirectoryPath")]
        public string CreateExtentDirectoryPath { get; set; }

        //Emp Search
        [JsonProperty("SearchEmpDirectory_sheet")]
        public string SearchEmpDirectory_sheet { get; set; }

        [JsonProperty("SearchEmpDirectoryPath")]
        public string SearchEmpDirectoryPath { get; set; }
        //Extent Report
        // "ExtentReport_Path": "D:\\SeleniumCodeUdemy\\ExtentDetails\\AutoReport",

        //[JsonProperty("ExtentReport_Path")]
        //public string ExtentReport_PathJson { get; set; }
    }
}
