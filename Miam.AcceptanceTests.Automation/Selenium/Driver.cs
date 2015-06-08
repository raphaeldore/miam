//using System;
//using System.Drawing.Imaging;
//using System.IO;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;

//namespace Miam.Web.Automation.Selenium
//{
//    public class Driver
//    {
//        public static IWebDriver Instance { get; set; }

//        public static string BaseAddress
//        {
//            get { return "http://miam.local"; }
//        }

//        public static void Initialize()
//        {
//            var fireFoxSeleniumProfile = CreateSeleniumPorfile(); 
//            Instance = new FirefoxDriver(fireFoxSeleniumProfile);
//            Instance.Manage().Window.Maximize();
            
//            //Selenium doit attendre 5 secondes avant d'indiquer qu'un objet n'est pas sur une page.
//            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

//            //Efface et peuple la BD avec des données pour les tests
//            Instance.Navigate().GoToUrl(BaseAddress + "/Ci");
//            //GetScreenShoot("ApresCI");
            
//            Instance.FindElement(By.Id("go_home")).Click();
//        }

//        public static void Close()
//        {
//            Instance.Close();
//        }

//        public static void GetScreenShoot(string screenShootName)
//        {
//            var screenShoot = ((ITakesScreenshot)Instance).GetScreenshot();
//            screenShoot.SaveAsFile(screenShootName + "_" +
//                                   DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + 
//                                   ".png", 
//                                   ImageFormat.Png);
//        }

//        public static FirefoxProfile CreateSeleniumPorfile()
//        {
//            // Configurer FireFox pour ne pas ouvrir de boite de dialogue si un utilisateur demande de télécharger un fichier.
//            var profile = new FirefoxProfile();
//            var applicationDirectory = Directory.GetCurrentDirectory();
//            profile.SetPreference("browser.download.dir", applicationDirectory);
//            profile.SetPreference("browser.download.folderList", 2);
//            profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
//            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream"); 
            
//            return profile;
//        }
//    }
//}