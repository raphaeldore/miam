using Miam.TestUtility.Database;
using Miam.Web.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class WriterTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Writer_Can_Add_A_Restaurant()
        {
            const string RESATURANT_NAME = "Lulu la patate";

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Writer1.Email).WithPassowrd(TestData.Writer1.Password).Login();

            RestaurantCreatePage.GoTo();
            RestaurantCreatePage.CreateRestaurant(RESATURANT_NAME)
                                .WithCity("Québec")
                                .WithCountry("Canada")
                                .Create();

            Assert.IsTrue(HomePage.Contain(RESATURANT_NAME), "Le nom du restaurat ne se trouve pas dans la page.");
        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}

 
