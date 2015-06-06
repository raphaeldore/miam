using System;
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

            Instance.Run(configure => configure
                .WithWebServer(new InternetWebServer("http://miam.local"))
                .WithRouteConfig(RouteConfig.RegisterRoutes)
                .WithMinimumWaitTimeoutOf(TimeSpan.FromSeconds(5))
            );
       }
    }
}
