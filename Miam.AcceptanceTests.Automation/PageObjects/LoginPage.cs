using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.AcceptanceTests.Automation.PageObjects
{
    public class LoginPage : Page
    {
        public HomePage LoginAs(string email, string password)
        {
            Find.Element(By.Id("Email"))
                .SendKeys(email);

            Find.Element(By.Id("Password"))
                .SendKeys(password);

            return Navigate.To<HomePage>(By.Id("login-submit"));
        }
    }
}
