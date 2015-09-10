using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.TestUtility.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.Authentification 
{

    class InvalidAuthentificationTests :BaseAcceptanceTests
    {
        private Domain.Entities.Writer _user;

        [TestMethod]
        public void s_authentifier_avec_courriel_invalide()
        {
            this.Given(x => un_utilisateur_existant_non_authentifé())
                .When(x => l_utilisateur_entre_un_mot_de_passe_valide_mais_inexistant())
                .Then(x => l_utilisateur_ne_devrait_pas_être_authentifié())
                .BDDfy();
        }

        private void un_utilisateur_existant_non_authentifé()
        {
            _user = TestData.Writer2;
            DbTestHelper.Users.Add(_user);
        }

        private void l_utilisateur_entre_un_mot_de_passe_valide_mais_inexistant()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .ClickLogin()
                .LoginAs(_user.Email, _user.Password + "invalid_password");
        }

        private void l_utilisateur_ne_devrait_pas_être_authentifié()
        {
            var islogged = Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .IsLoggedIn(_user.Email);

            Assert.IsFalse(islogged);
        }

        //[TestClass]
        //[Story(
        //    Title = "Un utilisateur peut s'authentifier",
        //    AsA = "En tant qu'utilisateur",
        //    IWant = "Je veux  m'authentifier",
        //    SoThat = "Afin d'avoir accès au système")]
        //public class UserAuthentification
        //{
        //    [TestMethod]
        //    public void s_authentifier_avec_courriel_vide()
        //    {
        //        this.When(x => un_utilisateur_entre_courriel_vide())
        //            .Then(x => l_utilisateur_est_informe())
        //            .BDDfy();
        //    }
        //}
    }
}
