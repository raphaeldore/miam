using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Miam.Web.Automation.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get { return "http://miam.local"; }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Window.Maximize();
            
            //Selenium doit attendre 5 secondes avant d'indiquer qu'un objet n'est pas sur une page.
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));


            Screenshot ss1 = ((ITakesScreenshot)Instance).GetScreenshot();
            ss1.SaveAsFile("avantCI.png", ImageFormat.Png);

            //Efface et peuple la BD avec des données pour les tests
            Instance.Navigate().GoToUrl(BaseAddress + "/Ci");
            Screenshot ss2 = ((ITakesScreenshot)Instance).GetScreenshot();
            ss2.SaveAsFile("apresCI.png", ImageFormat.Png);

            Instance.FindElement(By.Id("go_home")).Click();
            Screenshot ss3 = ((ITakesScreenshot)Instance).GetScreenshot();
            ss3.SaveAsFile("apresGoHome.png", ImageFormat.Png);

            

        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}