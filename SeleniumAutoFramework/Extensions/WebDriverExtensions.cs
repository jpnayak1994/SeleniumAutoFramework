using OpenQA.Selenium;
using SeleniumAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoFramework.Extensions
{
   public static class WebDriverExtensions
    {
        //Wait for the page to be loaded
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                //string state = dri.ExecuteJS("return document.readystate").ToString();
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";//page is completely loaded, if it completes then the expression evaluates true

            }, 15000);
        }

        public static void WaitForCondition<T>( this T obj,Func<T,bool> condition,int timeOut)
        {
            Func<T, bool> execute = (arg) =>
               {
                   try
                   {
                       return condition(arg);
                   }
                   catch (Exception ex)
                   {
                       var msg = ex.Message;
                       return false;
                   }
               };
            var stopwatch = Stopwatch.StartNew();
            while(stopwatch.ElapsedMilliseconds< timeOut)
            {
                if(execute(obj))
                {
                    break;
                }
            }
        }

        
    }
}
