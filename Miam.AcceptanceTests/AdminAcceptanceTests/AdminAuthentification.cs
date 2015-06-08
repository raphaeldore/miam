using FluentAssertions;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.TestUtility.Database;
using Miam.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.AdminAcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut s'authentifier",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin d'avoir accès au système")]
    public class AdminAuthentification : AdminBaseClass
    {
        [TestMethod]
        public void s_authentifier_avec_courriel_et_mot_de_passe_valide()
        {
            this.Given(x => un_administrateur_existant_non_authentifé())
                .When(x => l_administrateur_entre_son_courriel_et_mot_de_passe_valide())
                .Then(x => l_administrateur_devrait_être_authentifié())
                .BDDfy();
        }

        [TestMethod]
        public void s_authentifier_avec_courriel_invalide()
        {
            this.Given(x => un_administrateur_existant_non_authentifé())
                .When(x => l_administrateur_entre_un_mot_de_passe_invalide())
                .Then(x => l_administrateur_ne_devrait_pas_être_authentifié())
                .BDDfy();
        }

        private void un_administrateur_existant_non_authentifé()
        {
            _userAdmin = TestData.ApplicationUserAdmin;
            _userAcceptanceTestApi.createUser(_userAdmin);
        }
        private void l_administrateur_entre_son_courriel_et_mot_de_passe_valide()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .GotoLoginPage()
                .LoginAs(_userAdmin.Email, _userAdmin.Password);
        }
        private void l_administrateur_entre_un_mot_de_passe_invalide()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .GotoLoginPage()
                .LoginAs(_userAdmin.Email, _userAdmin.Password + "invalid_password");
        }

        private void l_administrateur_ne_devrait_pas_être_authentifié()
        {
            var isLoggedIn = Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .IsLoggedIn(_userAdmin.Email);

            Assert.IsFalse(isLoggedIn);
        }

        private void l_administrateur_devrait_être_authentifié()
        {
            var loggedInUserName = Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .LoggedInUserName;

            loggedInUserName.ShouldBeEquivalentTo(_userAdmin.Email);
            
        }
    }
}