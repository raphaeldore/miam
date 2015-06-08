using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Web.Controllers;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.AcceptanceTests.Automation.UiComponents
{
    public class NavigationMenu : UiComponent
    {
        public LoginPage GotoLoginPage()
        {
            return Navigate.To<LoginPage>(By.Id("login-link"));
;       }

        public EditRestaurantPage ClickEditRestaurantPage()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<EditRestaurantPage>(By.Id("manage-restaurant-menu-item"));
        }

        public CreateRestaurantPage ClickCreateRestaurantPage()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<CreateRestaurantPage>(By.Id("add-restaurant-menu-item"));
        }

        public EmailPage GoToEmailPage()
        {
            // Il n'ya pas de menu donc on utilise le lien URL et non un click dans un menu)
            return Host.Instance.NavigateToInitialPage<EmailController, EmailPage>(x => x.Send());
        }
    }
}
