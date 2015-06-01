using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

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

        [TestInitialize]
        public void initialize()
        {
            _userAcceptanceTestApi = new UserAcceptanceTestsApi();
            _databaseHelperAcceptanceTestApi = new DatabaseHelperAcceptanceTestApi();
            _databaseHelperAcceptanceTestApi.ClearDataBaseTables();
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
                .When(x => QuandLAdministrateurEntreSonMotDePasseValideEtCourrielInvalide())
                .Then(x => AlorsLAdministrateurNeDevraitPasÊtreAuthentifié())
                .BDDfy();
        }

        private void AlorsLAdministrateurNeDevraitPasÊtreAuthentifié()
        {
            //throw new System.NotImplementedException();
        }

        private void QuandLAdministrateurEntreSonMotDePasseValideEtCourrielInvalide()
        {
            //throw new System.NotImplementedException();
        }

        private void EtantDonnéUnAdministrateurExistantNonAuthentifé()
        {
            _userAcceptanceTestApi.createUser(TestData.ApplicationUserAdmin);

        }

        private void QuandLAdministrateurEntreSonCourrielEtMotDePasseValide()
        {
            // Se loguer via l'interface 
            Host.Instance.Application.Initialize();
        }

        private void AlorsLAdministrateurDevraitÊtreAuthentifié()
        {
            // Vérification
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
