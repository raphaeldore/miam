using FluentAssertions;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.AcceptanceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.WriterAcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un chroniqueur peut s'authentifier",
        AsA = "En tant que chroniqueur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin d'avoir écrire des commetaires")]
    public class WriterAuthentification : AcceptanceTestsBaseClass
    {
        private Writer _writer;

        [TestMethod]
        public void s_authentifier_avec_courriel_et_mot_de_passe_valide()
        {
            this.Given(x => un_chroniqueur_existant_non_authentifé())
                .When(x => le_chroniqueur_entre_son_courriel_et_mot_de_passe_valide())
                .Then(x => le_chroniqueur_devrait_être_authentifié())
                .BDDfy();
        }

        [TestMethod]
        public void s_authentifier_avec_courriel_invalide()
        {
            this.Given(x => un_chroniqueur_existant_non_authentifé())
                .When(x => le_chroniqueur_entre_un_mot_de_passe_invalide())
                .Then(x => le_chroniqueur_ne_devrait_pas_être_authentifié())
                .BDDfy();
        }

        private void un_chroniqueur_existant_non_authentifé()
        {
            _writer = TestData.Writer1;
            _testHelperApi.User.createUser(_writer);
        }

        private void le_chroniqueur_entre_son_courriel_et_mot_de_passe_valide()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            homePage
                .NavigationMenu
                .GotoLoginPage()
                .LoginAs(_writer.Email, _writer.Password);
        }
        private void le_chroniqueur_devrait_être_authentifié()
        {
            var loggedInUserName = Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .LoggedInUserName;

            loggedInUserName.ShouldBeEquivalentTo(_writer.Email);
        }

        private void le_chroniqueur_entre_un_mot_de_passe_invalide()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .GotoLoginPage()
                .LoginAs(_writer.Email, _writer.Password + "invalid_password");
        }

        private void le_chroniqueur_ne_devrait_pas_être_authentifié()
        {
            var islogged= Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .IsLoggedIn(_writer.Email);
            
            Assert.IsFalse(islogged);
        }
    }
}