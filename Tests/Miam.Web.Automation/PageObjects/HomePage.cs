using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects
{
    public class HomePage
    {
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

        public static bool Contain(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.CssSelector("body"));
            return body.Text.Contains(textToFind);
        }
    }
}
