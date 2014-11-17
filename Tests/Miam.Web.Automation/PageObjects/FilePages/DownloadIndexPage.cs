using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects.FilePages
{
    public class DownloadIndexPage:FileBasePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("download-index-page")) != null; }
        }
        public static void Goto()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "/File/Index");
        }
        public static void ClickFile(string filename)
        {
            var file = Driver.Instance.FindElement(By.PartialLinkText(filename));
            file.Click();

        }

        public static bool DoesFileNameDisplayed(string textToFind)
        {
            var page = Driver.Instance.FindElement(By.Id("files"));
            return page.Text.Contains(textToFind);

        }
    }
}
