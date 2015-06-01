using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.WebServers;

namespace Miam.Web.Automation.Seleno
{
    public static class Host
    {
        public static readonly SelenoHost Instance = new SelenoHost();

        static Host()
        {

            Instance.Run(configure => configure.WithWebServer(new InternetWebServer("http://miamtest.gear.host")));

            //Instance.Run("Miam.Web", 12346);
            ////, c => c
            ////    .UsingLoggerFactory(new ConsoleFactory())
            ////    .WithRouteConfig(RouteConfig.RegisterRoutes)
            ////);
        }
    }
}
