using System;
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
            
            //Selenium doir attendre 5 seconde avant d'indiquer qu'un objet n'est pas sur une page.
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            //Efface et peuple la BD avec des données
            Instance.Navigate().GoToUrl(BaseAddress + "/Ci");
            Instance.FindElement(By.Id("go_home")).Click();
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}