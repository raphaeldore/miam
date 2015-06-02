using Miam.Web.Automation.PageObjects.RestaurantPages;
using Miam.Web.Automation.Seleno;
using Miam.Web.Controllers;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects
{
    public class HomePage : Page
    {
        public LoginPage GoToLoginPage()
        {
            return Navigate.To<LoginPage>(By.Id("login-link"));
;       }

        public EditRestaurantPage GoToEditRestaurantPage()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<EditRestaurantPage>(By.Id("manage-restaurant-menu-item"));
        }

        public CreateRestaurantPage GoToCreateRestaurantPage()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<CreateRestaurantPage>(By.Id("add-restaurant-menu-item"));
        }

        public bool IsLogged(string email)
        {

            var navigationMenu = Find.Element(By.ClassName("navbar"));
            return navigationMenu.Text.Contains(email);
        }
        public void LogOut()
        {
            Host.Instance.NavigateToInitialPage<AccountController, LoginPage>(x => x.Logout());
        }

        public int RestaurantCount()
        {
            var countText = Find.Element(By.Id("restaurants-count"))
                                .Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}
