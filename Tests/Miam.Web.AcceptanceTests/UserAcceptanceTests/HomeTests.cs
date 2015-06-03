using Miam.Web.AcceptanceTests.AdminAcceptanceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.UserAcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un utilisateur peut voir la liste des restaurants",
        AsA = "En tant qu'utilisateur",
        IWant = "Je veux voir la liste des restaurants avec la moyenne des critiques",
        SoThat = "Afin de choisir un restaurant")]
    public class AdminAuthentification : AdminBaseClass
    {
        [TestMethod]
        public void voir_la_liste_des_restaurants()
        {
            this.Given(x => des_restaurants_avec_des_critiques())
                .When(x => l_utlisateur_accède_au_site())
                .Then(x => l_utlisateur_voit_une_liste_de_restaurants_avec_la_moyenne_des_critiques())
                .BDDfy();
        }

        private void des_restaurants_avec_des_critiques()
        {
            throw new System.NotImplementedException();
        }

        private void l_utlisateur_accède_au_site()
        {
            throw new System.NotImplementedException();
        }

        private void l_utlisateur_voit_une_liste_de_restaurants_avec_la_moyenne_des_critiques()
        {
            throw new System.NotImplementedException();
        }
    }
}