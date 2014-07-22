using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects.RestaurantPages
{
    public class ManageRestaurantPage
    {
        public static string FirstRestaurantName
        {
            get
            {
                var restaurants = Driver.Instance.FindElement(By.ClassName("list-group"));
                var firstRestaurant = restaurants.FindElement(By.CssSelector("H4")).Text;
                return firstRestaurant;
            }
        }

        public static Restaurant FirstRestaurant
        {
            get
            {
                Driver.Instance.FindElement(By.Id("edit_button1")).Click();
                return createRestaurantFromRestaurantField();;
            }
        }

        public static void GoTo()
        {
            Navigation.Admin.ManageRestaurant.Select();
        }


        public static void DeleteFirstRestaurant()
        {
            var deleteButton = Driver.Instance.FindElement(By.Id("delete_button1"));
            deleteButton.Click();

            var confirmButton = Driver.Instance.FindElement(By.TagName("input"));
            confirmButton.Click();
        }

        public static void ModifytFirstRestaurantWith(Restaurant newRestaurant)
        {
            Driver.Instance.FindElement(By.Id("edit_button1")).Click();
            ClearAllRestaurantFields();
            FillAllRestaurantFieldsWith(newRestaurant);
            Driver.Instance.FindElement(By.Id("submit_button")).Click();
        }

        private static void FillAllRestaurantFieldsWith(Restaurant newRestaurant)
        {
            Driver.Instance.FindElement(By.Id("Name")).SendKeys(newRestaurant.Name);
            Driver.Instance.FindElement(By.Id("City")).SendKeys(newRestaurant.City);
            Driver.Instance.FindElement(By.Id("Country")).SendKeys(newRestaurant.Country);
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_FaxPhone")).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_OfficePhone")).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_TwitterAlias")).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_Facebook")).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_WebPage")).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private static void ClearAllRestaurantFields()
        {
            Driver.Instance.FindElement(By.Id("Name")).Clear();
            Driver.Instance.FindElement(By.Id("City")).Clear();
            Driver.Instance.FindElement(By.Id("Country")).Clear();
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_FaxPhone")).Clear();
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_OfficePhone")).Clear();
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_TwitterAlias")).Clear();
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_Facebook")).Clear();
            Driver.Instance.FindElement(By.Id("RestaurantContactDetail_WebPage")).Clear();
        }

        private static Restaurant createRestaurantFromRestaurantField()
        {
            return new Restaurant()
            {
                Name = Driver.Instance.FindElement(By.Id("Name")).GetAttribute("value"),
                City = Driver.Instance.FindElement(By.Id("City")).GetAttribute("value"),
                Country = Driver.Instance.FindElement(By.Id("Country")).GetAttribute("value"),
                RestaurantContactDetail = new RestaurantContactDetail()
                {
                    Facebook = Driver.Instance.FindElement(By.Id("RestaurantContactDetail_Facebook")).GetAttribute("value"),
                    FaxPhone = Driver.Instance.FindElement(By.Id("RestaurantContactDetail_FaxPhone")).GetAttribute("value"),
                    OfficePhone =
                        Driver.Instance.FindElement(By.Id("RestaurantContactDetail_OfficePhone")).GetAttribute("value"),
                    TwitterAlias =
                        Driver.Instance.FindElement(By.Id("RestaurantContactDetail_TwitterAlias")).GetAttribute("value"),
                    WebPage = Driver.Instance.FindElement(By.Id("RestaurantContactDetail_WebPage")).GetAttribute("value")
                }
            };
        }

    }

    


}