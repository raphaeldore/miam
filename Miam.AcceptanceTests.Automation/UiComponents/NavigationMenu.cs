using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Web.Controllers;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.UiComponents
{
    public class NavigationMenu : UiComponent
    {
        public LoginPage ClickLogin()
        {
            return Navigate.To<LoginPage>(By.Id("login-link"));
;       }

        public EditRestaurantsPage ClickEditRestaurants()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<EditRestaurantsPage>(By.Id("manage-restaurant-menu-item"));
        }

        public CreateRestaurantPage ClickCreateRestaurant()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<CreateRestaurantPage>(By.Id("add-restaurant-menu-item"));
        }

        public EmailPage ClickSendEmail()
        {
            //Todo :ajouter un menu pour envoyer des courriels
            // Il n'y a pas de menu pour l'instant, donc on utilise le lien URL et non un click dans un menu.
            
            return Host.Instance.NavigateToInitialPage<EmailController, EmailPage>(x => x.Send());
        }
    }
}
