using System.Diagnostics;

namespace Miam.AcceptanceTests.Automation
{
    public static class AcceptanceTestsConfiguration
    {
        private const string AcceptanceTestsWebSiteUrlDebug = "http://miam.local";
        private const string AcceptanceTestsWebSiteUrlRelease = "http://miamtest.gear.host";
        private static bool debuggingMode;

        public static string WebSiteUrl
        {
            get
            {
                checkIfDebugMode();
                if (debuggingMode)
                {
                    return AcceptanceTestsWebSiteUrlDebug;
                }
                else
                {
                    return AcceptanceTestsWebSiteUrlRelease;
                }
            }
        }
        [Conditional("DEBUG")]
        private static void checkIfDebugMode()
        {
            debuggingMode = true;
        }
    }
}