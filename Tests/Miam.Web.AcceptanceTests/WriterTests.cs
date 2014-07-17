using Miam.TestUtility.Database;
using Miam.Web.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class WriterTests : MiamAcceptanceTests
    {
        [TestMethod]
        public void writer_can_add_a_restaurant()
        {
            const string RESATURANT_NAME = "Lulu la patate";

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Writer1.Email).WithPassowrd(TestData.Writer1.Password).Login();

            WriterCreateRestaurantPage.GoTo();
            WriterCreateRestaurantPage.CreateRestaurant(RESATURANT_NAME)
                                .WithCity("Québec")
                                .WithCountry("Canada")
                                .Create();

            Assert.IsTrue(HomePage.Contain(RESATURANT_NAME), "Le nom du restaurant ne se trouve pas dans la page.");
        }
    }
}

 
