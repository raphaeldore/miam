using Miam.Domain.Entities;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects.RestaurantPages
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
            Find.Element(By.Id("Name")).SendKeys(newRestaurant.Name);
            Find.Element(By.Id("City")).SendKeys(newRestaurant.City);
            Find.Element(By.Id("Country")).SendKeys(newRestaurant.Country);
            Find.Element(By.Id("RestaurantContactDetail_FaxPhone")).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Find.Element(By.Id("RestaurantContactDetail_OfficePhone")).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Find.Element(By.Id("RestaurantContactDetail_TwitterAlias")).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Find.Element(By.Id("RestaurantContactDetail_Facebook")).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Find.Element(By.Id("RestaurantContactDetail_WebPage")).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private void ClearAllRestaurantFields()
        {
            Find.Element(By.Id("Name")).Clear();
            Find.Element(By.Id("City")).Clear();
            Find.Element(By.Id("Country")).Clear();
            Find.Element(By.Id("RestaurantContactDetail_FaxPhone")).Clear();
            Find.Element(By.Id("RestaurantContactDetail_OfficePhone")).Clear();
            Find.Element(By.Id("RestaurantContactDetail_TwitterAlias")).Clear();
            Find.Element(By.Id("RestaurantContactDetail_Facebook")).Clear();
            Find.Element(By.Id("RestaurantContactDetail_WebPage")).Clear();
        }
    }
}