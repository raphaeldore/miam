using System;
using System.IO;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.WebServers;
using WebApplication1;

namespace Miam.AcceptanceTests.Automation.Seleno
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

       
        static Host()
        {
            Instance.Run(configure => configure
                .WithWebServer(new InternetWebServer("http://miam.local"))
                .WithRouteConfig(RouteConfig.RegisterRoutes)
                .WithMinimumWaitTimeoutOf(TimeSpan.FromSeconds(5))
                .WithRemoteWebDriver(fireFoxWebDriver)
            );

            Instance.Application.Browser.Manage().Window.Maximize();
        }

        static Func<RemoteWebDriver> fireFoxWebDriver = delegate()
        {
            var fireFoxSeleniumProfile = CreateSeleniumPorfile();
            return new FirefoxDriver(fireFoxSeleniumProfile);
        };

        public static FirefoxProfile CreateSeleniumPorfile()
        {
            // Configurer FireFox pour ne pas ouvrir de boite de dialogue si un utilisateur demande de télécharger un fichier.
            var profile = new FirefoxProfile();
            var applicationDirectory = Directory.GetCurrentDirectory();
            profile.SetPreference("browser.download.dir", applicationDirectory);
            profile.SetPreference("browser.download.folderList", 2);
            profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream");

            return profile;
        }
    }
}
