using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.AcceptanceTests.Automation.PageObjects
{
    public class EmailPage : Page
    {
        public EmailPage SendEamil()
        {
            return Navigate.To<EmailPage>(By.Id("submit_button"));
        }

    }
}
