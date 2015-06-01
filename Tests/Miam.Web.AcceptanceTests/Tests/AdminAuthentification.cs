using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;
using TestStack.Seleno.Extensions;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut s'authentifier",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin d'avoir accès au système")]
    public class AdminAuthentification
    {
        //private ApplicationUser _userAdmin;
        private UserAcceptanceTestsApi _userAcceptanceTestApi;
        private DatabaseHelperAcceptanceTestApi _databaseHelperAcceptanceTestApi;
        private HomePage _homePage;

        [TestInitialize]
        public void initialize()
        {
            _userAcceptanceTestApi = new UserAcceptanceTestsApi();
            _databaseHelperAcceptanceTestApi = new DatabaseHelperAcceptanceTestApi();
            _databaseHelperAcceptanceTestApi.ClearDataBaseTables();

            _homePage = Host.Instance.NavigateToInitialPage<HomePage>();
        }

        [TestCleanup]
        public void cleanup()
        {

            _homePage.LogOut();

        }

        [TestMethod]
        public void SauthentifierAvecCourrielEtMotDePasseValide()
        {
            this.Given(x => EtantDonnéUnAdministrateurExistantNonAuthentifé())
                .When(x => QuandLAdministrateurEntreSonCourrielEtMotDePasseValide())
                .Then(x => AlorsLAdministrateurDevraitÊtreAuthentifié())
                .BDDfy();
        }

        [TestMethod]
        public void SAuthentifierAvecCourrielInvalide()
        {
            this.Given(x => EtantDonnéUnAdministrateurExistantNonAuthentifé(), "Étant donné un administrateur non authentifié")
                .When(x => QuandLAdministrateurEntreUnMotDePasseInvalide())
                .Then(x => AlorsLAdministrateurNeDevraitPasÊtreAuthentifié())
                .BDDfy();
        }

        private void EtantDonnéUnAdministrateurExistantNonAuthentifé()
        {
            _userAcceptanceTestApi.createUser(TestData.ApplicationUserAdmin);
        }
        private void QuandLAdministrateurEntreSonCourrielEtMotDePasseValide()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var loginPage = homePage.GoToLoginPage();
            loginPage.SelenoLoginAs(TestData.ApplicationUserAdmin.Email, TestData.ApplicationUserAdmin.Password);
        }
        private void QuandLAdministrateurEntreUnMotDePasseInvalide()
        {
            var loginPage = _homePage.GoToLoginPage();
            loginPage.SelenoLoginAs(TestData.ApplicationUserAdmin.Email, "invalid_password");
        }

        private void AlorsLAdministrateurNeDevraitPasÊtreAuthentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.SelenoIsLogged(TestData.ApplicationUserAdmin.Email);

            Assert.IsFalse(islogged);
        }

        private void AlorsLAdministrateurDevraitÊtreAuthentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.SelenoIsLogged(TestData.ApplicationUserAdmin.Email);

            Assert.IsTrue(islogged);
        }
    }
}

//    public class AdminTests : MiamAcceptanceBaseClassTests
//    {
//        [TestInitialize]
//        public void initialize()
//        {
//            LoginPage.GoTo();
//            LoginPage.LoginAs(TestData.ApplicationUserAdmin);
//        }

//        [TestMethod]
//        public void admin_can_delete_restaurant()
//        {
//            HomePage.StoreRestaurtantCount();

//            EditRestaurantPage.GoTo();
//            EditRestaurantPage.DeleteFirstRestaurant();

//            HomePage.GoTo();
//            Assert.AreNotEqual(HomePage.PreviousRestaurantCount, HomePage.CurrentRestaurantCount);
//        }

//        [TestMethod]
//        public void admin_can_edit_restaurant()
//        {
//            EditRestaurantPage.GoTo();
//            EditRestaurantPage.ModifytFirstRestaurantWith(TestData.Restaurant3);

//            //assert
//            EditRestaurantPage.FirstRestaurant.ShouldBeEquivalentTo(TestData.Restaurant3);
//        }

//        [TestMethod]
//        public void admin_can_add_a_restaurant()
//        {
//            //arrange
//            var restaurant = _fixture.Create<Restaurant>();

//            //action
//            HomePage.StoreRestaurtantCount();
//            CreateRestaurantPage.GoTo();
//            CreateRestaurantPage.CreateRestaurant(restaurant);

//            //Assert
//            Assert.AreEqual(HomePage.PreviousRestaurantCount + 1, HomePage.CurrentRestaurantCount);
//            Assert.IsTrue(HomePage.DoesRestaurantNameExist(restaurant.Name), "Le nom du restaurant ne se trouve pas dans la page.");
//        }
//    }
//}
