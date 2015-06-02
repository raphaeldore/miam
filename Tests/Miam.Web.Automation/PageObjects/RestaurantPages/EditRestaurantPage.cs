using System;
using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects.RestaurantPages
{
    public class EditRestaurantPage : Page
    {
        //Seleno
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


        //Avant 


        public static bool IsDisplayed
        {
            get{ return Driver.Instance.FindElement(By.Id("edit-restaurant-page")) != null; }
        }

        public static Restaurant FirstRestaurant
        {
            get
            {
                Driver.Instance.FindElement(By.Id("edit_button1")).Click();
                return createRestaurantFromRestaurantField(); ;
            }
        }

        public static void GoTo()
        {
            Navigation.Admin.EditRestaurant.Select();
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
            //ClearAllRestaurantFields();
            //FillAllRestaurantFieldsWith(newRestaurant);
            Driver.Instance.FindElement(By.Id("submit_button")).Click();
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