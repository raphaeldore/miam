using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.TestUtility.Database;
using OpenQA.Selenium;

namespace Miam.Web.Automation
{
    public class HomePage
    {
        public static bool IsAdminLogged
        {
            get
            {
                var body = Driver.Instance.FindElement(By.ClassName("navbar"));
                return body.Text.Contains("Admin");
            } 
        }
    }
}
