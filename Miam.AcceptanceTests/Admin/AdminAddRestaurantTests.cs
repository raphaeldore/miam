using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.TestUtility.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.Admin
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut ajouter un restaurant",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux pouvoir ajouter un restaurant",
        SoThat = "Afin d'avoir un nouveau restaurant dans le système")]
    public class AdminAddRestaurantTests : AdminTests
    {
        [TestMethod]
        public void ajouter_un_restaurant()
        {
            this.Given(x => un_administrateur_authentifé())
                .When(x => l_administrateur_ajoute_un_restaurant())
                .Then(x => le_restaurant_est_ajouté())
                .BDDfy();
        }

        private void l_administrateur_ajoute_un_restaurant()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .ClickCreateRestaurant()
                .AddRestaurant(TestData.Restaurant2);
        }

        private void le_restaurant_est_ajouté()
        {
            var restaurant = TestHelperApi.Restaurants.GetFirst();
            AssertRestaurantsShouldBeEquivalent(TestData.Restaurant2, restaurant);
        }
    }
}
