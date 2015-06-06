using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects
{
    public class EmailPage : Page
    {
        public EmailPage SendEamil()
        {
            return Navigate.To<EmailPage>(By.Id("submit-button"));
        }

    }
}
