using Miam.AcceptanceTests.Automation.UiComponents;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.AcceptanceTests.Automation.PageObjects
{
    public class HomePage : Page
    {
        public NavigationMenu NavigationMenu
        {
            get { return GetComponent<NavigationMenu>(); }
        }

        public LoginPanel LoginPanel
        {
            get { return GetComponent<LoginPanel>(); }
        }

        public int RestaurantCount()
        {
            var countText = Find.Element(By.Id("restaurants-count"))
                                .Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        
    }
}
