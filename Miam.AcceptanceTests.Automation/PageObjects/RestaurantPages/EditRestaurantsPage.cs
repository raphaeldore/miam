using Miam.AcceptanceTests.Automation.HtmlIdTag;
using Miam.Domain.Entities;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages
{
    public class EditRestaurantsPage : Page
    {
        public void DeleteFisrtRestaurant()
        {
            var deleteButton = Find.Element(By.CssSelector("a[id*='delete_button']"));
            deleteButton.Click();

            var confirmButton = Find.Element(By.TagName("input"));
            confirmButton.Click();
        }

        public void EditFisrtRestaurantWith(Restaurant newRestaurant)
        {
            Find.Element(By.CssSelector("a[id*='edit_button']")).Click();
            ClearAllRestaurantFields();
            FillAllRestaurantFieldsWith(newRestaurant);
            Find.Element(By.Id("submit_button")).Click();
        }

        private void FillAllRestaurantFieldsWith(Restaurant newRestaurant)
        {
            Find.Element(By.Id(Id.Restaurant.Name)).SendKeys(newRestaurant.Name);
            Find.Element(By.Id(Id.Restaurant.City)).SendKeys(newRestaurant.City);
            Find.Element(By.Id(Id.Restaurant.Country)).SendKeys(newRestaurant.Country);
            Find.Element(By.Id(Id.Restaurant.FaxPhone)).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Find.Element(By.Id(Id.Restaurant.OfficePhone)).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Find.Element(By.Id(Id.Restaurant.Twitter)).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Find.Element(By.Id(Id.Restaurant.FaceBook)).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Find.Element(By.Id(Id.Restaurant.WebPage)).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private void ClearAllRestaurantFields()
        {
            Find.Element(By.Id(Id.Restaurant.Name)).Clear();
            Find.Element(By.Id(Id.Restaurant.City)).Clear();
            Find.Element(By.Id(Id.Restaurant.Country)).Clear();
            Find.Element(By.Id(Id.Restaurant.FaxPhone)).Clear();
            Find.Element(By.Id(Id.Restaurant.OfficePhone)).Clear();
            Find.Element(By.Id(Id.Restaurant.Twitter)).Clear();
            Find.Element(By.Id(Id.Restaurant.FaceBook)).Clear();
            Find.Element(By.Id(Id.Restaurant.WebPage)).Clear();
        }
    }
}