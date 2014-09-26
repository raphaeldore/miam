using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Miam.Web.Automation.PageObjects.ReviewPages
{
    public class CreateReviewPage
    {
        public static void GoTo()
        {
            Navigation.Writer.CreateReview.Select();
        }


        public static void CreateReviewForFirstRestaurant(Review review)
        {
            var restaurantList = new SelectElement(Driver.Instance.FindElement(By.Id("RestaurantId")));
            restaurantList.SelectByIndex(1);


            Driver.Instance.FindElement(By.Id("Body")).SendKeys(review.Body);
            Driver.Instance.FindElement(By.Id("Rating")).SendKeys(review.Rating.ToString());

            Driver.Instance.FindElement(By.Id("create_button")).Click();
        }
    }
}
