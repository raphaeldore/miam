using OpenQA.Selenium;

namespace Miam.Web.Automation
{
    public class AdminPage
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
        
        public static void Goto()
        {
            var adminMenu = Driver.Instance.FindElement(By.Id("admin_menu"));
            adminMenu.Click();

            var editRestaurantMenuItem = Driver.Instance.FindElement(By.Id("edit_restaurant"));
            editRestaurantMenuItem.Click();
        }


        public static void DeleteFirstRestaurant()
        {
            var deleteButton = Driver.Instance.FindElement(By.Id("delete_button1"));
            deleteButton.Click();

            var confirmButton = Driver.Instance.FindElement(By.TagName("input"));
            confirmButton.Click();

        }
    }
}