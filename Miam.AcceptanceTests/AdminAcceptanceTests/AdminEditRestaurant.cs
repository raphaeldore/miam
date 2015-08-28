using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.TestUtility.Seed;
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
                .Given(x => un_restaurant())
                .When(x => l_administrateur_edit_un_restaurant())
                .Then(x => le_restaurant_est_mis_à_jour())
                .BDDfy();
        }

        private void l_administrateur_edit_un_restaurant()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .ClickEditRestaurantPage()
                .EditFisrtRestaurantWith(TestData.Restaurant3);
        }

        private void le_restaurant_est_mis_à_jour()
        {
            var restaurant = _testHelperApi.Restaurants.GetFirst();
            AssertRestaurantsShouldBeEquivalent(TestData.Restaurant3, restaurant);
            AssertContactDetailsShouldBeEquivalent(TestData.Restaurant3.RestaurantContactDetail, restaurant.RestaurantContactDetail);
        }
    }
}
