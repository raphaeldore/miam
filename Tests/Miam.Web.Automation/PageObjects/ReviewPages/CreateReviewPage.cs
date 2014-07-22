using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Miam.Web.Automation.PageObjects.ReviewPages
{
    public  class CreateReviewPage
    {
        public static void GoTo()
        {
            Navigation.Writer.CreateReview.Select();
        }

        public static CreateReviewCommand CreateRestaurant(string restaurantName)
        {
            return new CreateReviewCommand(restaurantName);
        }

        public static CreateReviewCommand CreateReviewForFirstRestaurant(string reviewBody)
        {
            return new CreateReviewCommand(reviewBody);
        }
    }

    public class CreateReviewCommand
    {
        private string _reviewBody;
        private int _rating;

        public CreateReviewCommand(string reviewBody)
        {
            _reviewBody = reviewBody;
        }

        public CreateReviewCommand WithRating(int rating)
        {
            _rating = rating;
            return this;
        }

        public void Create()
        {
            var restaurantList = new SelectElement(Driver.Instance.FindElement(By.Id("RestaurantId")));
            restaurantList.SelectByIndex(1);


            Driver.Instance.FindElement(By.Id("Body")).SendKeys("Incroybalement mauvais");
            Driver.Instance.FindElement(By.Id("Rating")).SendKeys("1");

            Driver.Instance.FindElement(By.Id("create_button")).Click();
        }
    }
}