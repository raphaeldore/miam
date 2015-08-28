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
            Find.Element(By.Id(GetRestaurantIDs.NameId)).SendKeys(newRestaurant.Name);
            Find.Element(By.Id(GetRestaurantIDs.CityId)).SendKeys(newRestaurant.City);
            Find.Element(By.Id(GetRestaurantIDs.CountryId)).SendKeys(newRestaurant.Country);
            Find.Element(By.Id(GetRestaurantIDs.FaxPhoneId)).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Find.Element(By.Id(GetRestaurantIDs.OfficePhoneId)).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Find.Element(By.Id(GetRestaurantIDs.TwitterId)).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Find.Element(By.Id(GetRestaurantIDs.FaceBookId)).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Find.Element(By.Id(GetRestaurantIDs.WebPageId)).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private void ClearAllRestaurantFields()
        {
            Find.Element(By.Id(GetRestaurantIDs.NameId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.CityId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.CountryId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.FaxPhoneId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.OfficePhoneId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.TwitterId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.FaceBookId)).Clear();
            Find.Element(By.Id(GetRestaurantIDs.WebPageId)).Clear();
        }
    }
}