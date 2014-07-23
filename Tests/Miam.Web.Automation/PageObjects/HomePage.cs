using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects
{
    public class HomePage
    {
        private static int _lastCount;
        public static bool IsAdminLogged
        {
            get
            {
                var body = Driver.Instance.FindElement(By.ClassName("navbar"));
                return body.Text.Contains("Admin");
            } 
        }
        public static bool IsWriterLogged
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("writer-menu")) != null; 
            }
        }
        public static bool IsDisplayed
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("home-page")) != null; 
            }
        }
        public static bool HasRestaurant
        {
            get
            {
                return GetRestaurantCount() > 0; 
            }
        }

        public static int PreviousRestaurantCount
        {
            get { return _lastCount; }
        }
        public static void StoreRestaurtantCount()
        {
            _lastCount = GetRestaurantCount();
        }
        public static int CurrentRestaurantCount
        {
            get { return GetRestaurantCount(); }
        }
        private static int GetRestaurantCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("restaurants-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesRestaurantNameExist(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.ClassName("list-group"));
            return body.Text.Contains(textToFind);
        }

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }
    }
}
