using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects.RestaurantPages
{
    public class CreateRestaurantPage
    {
        public static void GoTo()
        {
            Navigation.Admin.CreateRestaurant.Select();
        }

        public static void CreateRestaurant(Restaurant restaurant)
        {
            Driver.Instance.FindElement(By.Id("Name")).SendKeys(restaurant.Name);
            Driver.Instance.FindElement(By.Id("City")).SendKeys(restaurant.City);
            Driver.Instance.FindElement(By.Id("Country")).SendKeys(restaurant.Country);

            Driver.Instance.FindElement(By.Id("create_button")).Click();
        }
    }
}