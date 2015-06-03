using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.AcceptanceTests.AdminAcceptanceTests;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.WriterAcceptanceTests
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
            _userAcceptanceTestApi.createUser(_writer);
        }

        private void le_chroniqueur_entre_son_courriel_et_mot_de_passe_valide()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            homePage
                .Menu
                .GotoLoginPage()
                .LoginAs(_writer.Email, _writer.Password);
        }
        private void le_chroniqueur_devrait_être_authentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.IsLogged(_writer.Email);

            Assert.IsTrue(islogged);
        }

        private void le_chroniqueur_entre_un_mot_de_passe_invalide()
        {
            _homePage.Menu
                .GotoLoginPage()
                .LoginAs(_writer.Email, _writer.Password + "invalid_password");
        }

        private void le_chroniqueur_ne_devrait_pas_être_authentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.IsLogged(_writer.Email);

            Assert.IsFalse(islogged);
        }
    }
}