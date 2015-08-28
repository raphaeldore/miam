using Externalization;
using Miam.Domain.Entities;
using Miam.TestUtility;
using Miam.Web.ViewModels.Restaurant;
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
            Find.Element(By.Id(getRestaurantNameId())).SendKeys(newRestaurant.Name);
            Find.Element(By.Id(getRestaurantCityId())).SendKeys(newRestaurant.City);
            Find.Element(By.Id(getRestaurantCountryId())).SendKeys(newRestaurant.Country);
            Find.Element(By.Id(getFaxPhoneId())).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Find.Element(By.Id(getOfficePhoneID())).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Find.Element(By.Id(getTwitterAlliasId())).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Find.Element(By.Id(getFaceBookId())).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Find.Element(By.Id(getWebPageId())).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private void ClearAllRestaurantFields()
        {
            Find.Element(By.Id(getRestaurantNameId())).Clear();
            Find.Element(By.Id(getRestaurantCityId())).Clear();
            Find.Element(By.Id(getRestaurantCountryId())).Clear();
            Find.Element(By.Id(getFaxPhoneId())).Clear();
            Find.Element(By.Id(getOfficePhoneID())).Clear();
            Find.Element(By.Id(getTwitterAlliasId())).Clear();
            Find.Element(By.Id(getFaceBookId())).Clear();
            Find.Element(By.Id(getWebPageId())).Clear();
        }

        private string getRestaurantCountryId()
        {
            return ObjectsTool<RestaurantViewModel>.GetPropertyName(x => x.Country);
        }

        private string getRestaurantCityId()
        {
            return ObjectsTool<RestaurantViewModel>.GetPropertyName(x => x.City);
        }

        private string getRestaurantNameId()
        {
            return ObjectsTool<RestaurantViewModel>.GetPropertyName(x => x.Name);
        }
        private string getContactDetailName()
        {
            return ObjectsTool<RestaurantViewModel>.GetPropertyName(x => x.ContactDetailViewModel);
        }
        private string getFaxPhoneId()
        {
            return getContactDetailName() + "_" + ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.FaxPhone);
        }
        private string getWebPageId()
        {
            return getContactDetailName() + "_" + ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.WebPage);
        }

        private string getFaceBookId()
        {
            return getContactDetailName() + "_" + ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.Facebook);
        }

        private string getTwitterAlliasId()
        {
            return getContactDetailName() + "_" + ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.TwitterAlias);
        }

        private string getOfficePhoneID()
        {
            return getContactDetailName() + "_" + ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.OfficePhone);
        }

    }
}