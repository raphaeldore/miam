using Miam.AcceptanceTests.Automation.HtmlIdTag;
using Miam.Domain.Entities;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages
{
    public class EditRestaurantPage : Page
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
            Find.Element(By.Id(RestaurantIDs.Name)).SendKeys(newRestaurant.Name);
            Find.Element(By.Id(RestaurantIDs.City)).SendKeys(newRestaurant.City);
            Find.Element(By.Id(RestaurantIDs.Country)).SendKeys(newRestaurant.Country);
            Find.Element(By.Id(RestaurantIDs.FaxPhone)).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Find.Element(By.Id(RestaurantIDs.OfficePhone)).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Find.Element(By.Id(RestaurantIDs.Twitter)).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Find.Element(By.Id(RestaurantIDs.FaceBook)).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Find.Element(By.Id(RestaurantIDs.WebPage)).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private void ClearAllRestaurantFields()
        {
            Find.Element(By.Id(RestaurantIDs.Name)).Clear();
            Find.Element(By.Id(RestaurantIDs.City)).Clear();
            Find.Element(By.Id(RestaurantIDs.Country)).Clear();
            Find.Element(By.Id(RestaurantIDs.FaxPhone)).Clear();
            Find.Element(By.Id(RestaurantIDs.OfficePhone)).Clear();
            Find.Element(By.Id(RestaurantIDs.Twitter)).Clear();
            Find.Element(By.Id(RestaurantIDs.FaceBook)).Clear();
            Find.Element(By.Id(RestaurantIDs.WebPage)).Clear();
        }
    }
}