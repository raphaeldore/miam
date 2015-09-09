using System;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace Miam.Web
{
    public static class MiamEnvironmentVariable
    {
        public static string WebSiteAcceptanceTestsUrl { get; private set;}
        public static string mailPasswordSenGrid { get; private set; }
        public static string mailAccountSendGrid { get; private set; }
        public static string applicationEnvironment { get; private set; }
        public static void Initialize()
        {
            // Mettre ici toutes les variables d'environement afin d'éviter les "magical string" dans l'application
            // Les variables d'environement sont déclarées dans web.config, web.config.release et web.config.debug

            //WebSiteAcceptanceTestsUrl = Environment.GetEnvironmentVariable("WebSiteAcceptanceTestsURL");
            mailAccountSendGrid = Environment.GetEnvironmentVariable("MailAccountSendGrid");
            mailPasswordSenGrid = Environment.GetEnvironmentVariable("MailPasswordSenGrid");
            applicationEnvironment = Environment.GetEnvironmentVariable("ApplicationEnvironment");

            //if (WebSiteAcceptanceTestsUrl.IsEmpty()) throw new Exception("Variable d'environement vide");
            //if (mailAccountSendGrid.IsEmpty()) throw new Exception("Variable d'environement vide");
            //if (mailPasswordSenGrid.IsEmpty()) throw new Exception("Variable d'environement vide");
            //if (applicationEnvironment.IsEmpty()) throw new Exception("Variable d'environement vide");
        }
    }
}