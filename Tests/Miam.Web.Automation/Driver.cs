using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Miam.Web.Automation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            
            //Selenium doir attendre 5 seconde avant d'indiquer qu'un objet n'est pas sur une page.
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}