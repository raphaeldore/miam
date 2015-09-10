using System.Web.UI;
using Miam.AcceptanceTests.Automation.HtmlIdTag;
using TestStack.Seleno.PageObjects.Locators;
using Page = TestStack.Seleno.PageObjects.Page;

namespace Miam.AcceptanceTests.Automation.PageObjects
{
    public class LoginPage : Page
    {
        public HomePage LoginAs(string email, string password)
        {
            Find.Element(By.Id(Id.Account.Email))
                .SendKeys(email);

            Find.Element(By.Id(Id.Account.Password))
                .SendKeys(password);

            return Navigate.To<HomePage>(By.Id("login-submit"));
        }
    }
}
