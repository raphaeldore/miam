using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects.RestaurantPages
{
    public class CreateRestaurantPage : Page
    {
        // Seleno 
        public void AddRestaurant(Restaurant newRestaurant)
        {
            FillAllRestaurantFieldsWith(newRestaurant);
            Find.Element(By.Id("create_button")).Click();
        }

        private void FillAllRestaurantFieldsWith(Restaurant newRestaurant)
        {
            Find.Element(By.Id("Name")).SendKeys(newRestaurant.Name);
            Find.Element(By.Id("City")).SendKeys(newRestaurant.City);
            Find.Element(By.Id("Country")).SendKeys(newRestaurant.Country);
        }

        //


        public static void GoTo()
        {
            Navigation.Admin.CreateRestaurant.Select();
        }


    }
}