using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoFramework.Extensions
{
    public static class WebElementExtensions
    {
        //Want to get the dropdownvalue that I selected in the UI
        public static string GetSelectedDropdown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.FirstOrDefault().ToString();
        }
        //Want to get the selected options to be available in the dropdown
        public static IList<IWebElement> GetSelectedDropdownListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        //Used in HomePage
        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        //To select dropdown from from dropdown list buttons
        public static void SelectDropDownList(this IWebElement element ,string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        //To check whether that particular element present or not
        public static void AssertElementPresent(this IWebElement element)
        {
            if(!IsElementPresent(element))
            { throw new Exception(string.Format("Element not present Exception"));
            }
        }

       
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch(Exception)
            {
                return false;
                
            }
        }
    }
}
