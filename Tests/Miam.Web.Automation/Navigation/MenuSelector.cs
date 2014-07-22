using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation
{
    public class MenuSelector
    {
        public static void Select(string topLevelMenuId, string subLevelMenuId)
        {
            var adminMenu = Driver.Instance.FindElement(By.Id(topLevelMenuId));
            adminMenu.Click();

            var editRestaurantMenuItem = Driver.Instance.FindElement(By.Id(subLevelMenuId));
            editRestaurantMenuItem.Click();
        }
    }
}