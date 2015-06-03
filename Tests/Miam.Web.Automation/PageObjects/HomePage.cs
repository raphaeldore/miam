using Miam.Web.Automation.PageObjects.RestaurantPages;
using Miam.Web.Automation.Seleno;
using Miam.Web.Controllers;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects
{
    public class HomePage : Page
    {
        public NavigationMenu Menu
        {
            get { return GetComponent<NavigationMenu>(); }
        }

        public bool IsLogged(string email)
        {

            var navigationMenu = Find.Element(By.ClassName("navbar"));
            return navigationMenu.Text.Contains(email);
        }
        
        public int RestaurantCount()
        {
            var countText = Find.Element(By.Id("restaurants-count"))
                                .Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        
    }
}
