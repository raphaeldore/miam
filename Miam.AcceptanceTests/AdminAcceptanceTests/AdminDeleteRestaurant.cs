using FluentAssertions;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.AdminAcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut supprimer un restaurant",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux pouvoir supprimer un restaurant",
        SoThat = "Afin qu'il ne soit plus dans le système")]
    public class AdminDeleteRestaurant : AdminBaseClass
    {
        [TestMethod]
        public void supprimer_un_restaurant()
        {
            this.Given(x => un_administrateur_authentifé())
                .Given(x => un_restaurant())
                .When(x => l_administrateur_supprime_un_restaurant())
                .Then(x => le_restaurant_est_supprimé())
                .BDDfy();
        }

        private void l_administrateur_supprime_un_restaurant()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .ClickEditRestaurantPage()
                .DeleteFisrtRestaurant();

        }
        private void le_restaurant_est_supprimé()
        {
            //todo
            var countRestaurant = Host.Instance.NavigateToInitialPage<HomePage>()
                                    .RestaurantCount();
            countRestaurant.ShouldBeEquivalentTo(0);
        }




    }

}
