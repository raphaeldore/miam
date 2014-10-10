using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.TestUtility.Database;
using Miam.Web.Automation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests.Tests
{
    [TestClass]
    public class HomeTests:MiamAcceptanceTests
    {
        [TestMethod]
        public void home_page_should_display_restaurants()
        {
            HomePage.GoTo();
            Assert.IsTrue(HomePage.HasRestaurant);
        }

    }
}
