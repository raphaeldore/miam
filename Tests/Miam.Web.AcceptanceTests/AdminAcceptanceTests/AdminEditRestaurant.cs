using Miam.TestUtility.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.AdminAcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut editer un restaurant",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux pouvoir metttre à jour un restaurant",
        SoThat = "Afin d'avoir les informations sur un restaurant à jour")]
    public class AdminEditRestaurant : AdminBaseClass
    {
        [TestMethod]
        public void editer_un_restaurant()
        {
            this.Given(x => un_administrateur_authentifé())
                .Given(x => un_restaurant_existe_dans_le_système())
                .When(x => l_administrateur_edit_un_restaurant())
                .Then(x => le_restaurant_est_mis_à_jour())
                .BDDfy();
        }

        private void l_administrateur_edit_un_restaurant()
        {
            var editRestaurantPage = _homePage.GoToEditRestaurantPage();
            editRestaurantPage.EditFisrtRestaurantWith(TestData.Restaurant3);
        }

        private void le_restaurant_est_mis_à_jour()
        {
            var restaurant = _restaurantAcceptanceTestApi.GetFirstRestaurant();
            AssertRestaurantsShouldBeEquivalent(TestData.Restaurant3, restaurant);
            AssertContactDetailsShouldBeEquivalent(TestData.Restaurant3.RestaurantContactDetail, restaurant.RestaurantContactDetail);
        }
    }
}
