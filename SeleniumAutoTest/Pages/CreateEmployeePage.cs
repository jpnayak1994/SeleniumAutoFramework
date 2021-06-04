using OpenQA.Selenium;
using SeleniumAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutoTest.Pages
{
    public class CreateEmployeePage:BasePage
    {
        public CreateEmployeePage(ParallelConfig parallelConfig, LoggingStep loggingStep) : base(parallelConfig, loggingStep)
        {
        }
        IWebElement txtName => _parallelConfig.Driver.FindElement(By.Id("Name"));

        IWebElement txtSalary => _parallelConfig.Driver.FindElement(By.Id("Salary"));

        IWebElement txtDurationWorked => _parallelConfig.Driver.FindElement(By.Id("DurationWorked")); 

        IWebElement txtGrade => _parallelConfig.Driver.FindElement(By.Id("Grade")); 

        IWebElement txtEmail => _parallelConfig.Driver.FindElement(By.Id("Email"));

        IWebElement btnCreateEmployee => _parallelConfig.Driver.FindElement(By.XPath("//input[@value='Create']"));


        internal EmployeeListPage ClickCreateButton()
        {
            btnCreateEmployee.Submit();
            //return new EmployeeListPage(_parallelConfig);
            return new EmployeeListPage(_parallelConfig, loggingStep);
        }


        internal void CreateEmployee(string name, string salary, string durationworked, string grade, string email)
        {
            txtName.SendKeys(name);
            txtSalary.SendKeys(salary);
            txtDurationWorked.SendKeys(durationworked);
            txtGrade.SendKeys(grade);
            txtEmail.SendKeys(email);
        }

    }
}

