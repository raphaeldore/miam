
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.PageObjects
{
    public class EmailPage : Page
    {
        public EmailPage SubmitEmail()
        {
            return Navigate.To<EmailPage>(By.Id("submit_button"));
        }

    }
}
