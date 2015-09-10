using Externalization;
using Miam.AcceptanceTests.Automation.HtmlIdTag;
using Miam.Domain.Entities;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages
{
    public class CreateRestaurantPage : Page
    {
        public void AddRestaurant(Restaurant newRestaurant)
        {
            FillAllRestaurantFieldsWith(newRestaurant);
            Find.Element(By.Id("create_button")).Click();
        }

        private void FillAllRestaurantFieldsWith(Restaurant newRestaurant)
        {
            Find.Element(By.Id(Id.Restaurant.Name)).SendKeys(newRestaurant.Name);
            Find.Element(By.Id(Id.Restaurant.City)).SendKeys(newRestaurant.City);
            Find.Element(By.Id(Id.Restaurant.Country)).SendKeys(newRestaurant.Country);
        }
    }
}