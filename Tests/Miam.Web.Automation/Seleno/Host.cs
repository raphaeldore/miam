using System;
using System.IO;
using System.Windows;
using OpenQA.Selenium.Firefox;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.WebServers;
using TestStack.Seleno.Extensions;
using WebApplication1;


namespace Miam.Web.Automation.Seleno
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

        static Host()
        {
            //Todo: utiliser les profiles
            //var fireFoxSeleniumProfile = CreateSeleniumPorfile(); 
            //Instance2 = new FirefoxDriver(fireFoxSeleniumProfile);

            

            Instance.Run(configure => configure
                .WithWebServer(new InternetWebServer("http://miam.local"))
                .WithRouteConfig(RouteConfig.RegisterRoutes)
                .WithMinimumWaitTimeoutOf(TimeSpan.FromSeconds(5))
                //.WithRemoteWebDriver()
            );
            Instance.Application.Browser.Manage().Window.Maximize();
        }

        //public static FirefoxProfile CreateSeleniumPorfile()
        //{
        //    // Configurer FireFox pour ne pas ouvrir de boite de dialogue si un utilisateur demande de télécharger un fichier.
        //    var profile = new FirefoxProfile();
        //    var applicationDirectory = Directory.GetCurrentDirectory();
        //    profile.SetPreference("browser.download.dir", applicationDirectory);
        //    profile.SetPreference("browser.download.folderList", 2);
        //    profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
        //    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream");

        //    return profile;
        //}
    }
}
