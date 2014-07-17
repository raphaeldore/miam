using OpenQA.Selenium;

namespace Miam.Web.Automation
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

        public static bool IsUserLogged
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
