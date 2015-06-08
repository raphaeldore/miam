using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Web.Controllers;

using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.UiComponents
{
    public class LoginPanel : UiComponent
    {
        public string LoggedInUserName
        {
            get { return Find.Element(By.Id("login-username")).Text; }
        }

        public void ForceLogout()
        {
            Host.Instance.NavigateToInitialPage<AccountController, LoginPage>(x => x.Logout());
        }

        public void Logout()
        {
            Find.Element(By.Id("logout-link"))
                .Click();
        }


        public bool IsLoggedIn(string email)
        {
            var navigationMenu = Find.Element(By.ClassName("navbar"));
            return navigationMenu.Text.Contains(email);
        }

    }
}
