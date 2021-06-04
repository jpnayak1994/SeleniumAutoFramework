using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  SeleniumAutoFramework.Base;

namespace SeleniumAutoFramework.Config
{
    public static class Settings
    {
        //With GlobalConfig.xml
       // private int Age;
        public static string Testtype { get; set; }
        public static string AUT { get; set; }
        //public static string AUTs { get; set; }
       
        public static string BuildName { get; set; }
        public static BrowserType Browsertype { get; set; }
        public static string IsLog { get; set; }

        public static string LogPath { get; set; }
        public static string IsReport { get; set; }

        public static string UserName { get; set; }
        public static string Technology {get;set;}
        

        ////With Configuration appsetting.json
       public static int Config_Timeout { get; set; }

        public static string Config_IsReporting { get; set; }

        public static string Config_TestType { get; set; }

        public static string Config_AUT { get; set; }

        public static string Config_BuildName { get; set; }

        public static BrowserType Config_BrowserType { get; set; }
       // public static BrowserType Config_Browser2Type { get; set; }


        public static string Config_AppConnectionString { get; set; }

        public static string Config_IsLog { get; set; }

        private static bool _Config_fileCreated = false;

        //Log
        public static string Config_Login_excel_sheet { get; set; }
        public static string Config_LogPath { get; set; }
        public static string Config_LogPathDirectory { get; set; }
        public static int Config_Login_excel_rowNo { get; set; }

        //Create Emp
        public static string Config_CreateEmp_sheet { get; set; }
        public static string Config_CreateExtent_Directory { get; set; }

        //Emp Search
        public static string Config_EmpSearch_sheet { get; set; }
        public static string Config_EmpSearch_Directory { get; set; }
        //Extent Report
      //  public static string ExtentReportPathConfig { get; set; }
        public static bool Config_FileCreated
        {
            get
            {
                return _Config_fileCreated;
            }
            set
            {
                _Config_fileCreated = value;
            }
        }
    }

}
