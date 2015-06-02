using Miam.TestUtility.Database;
using Miam.Web.AcceptanceTests.Admin;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.Writer
{
    [TestClass]
    [Story(
        Title = "Un chroniqueur peut s'authentifier",
        AsA = "En tant que chroniqueur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin d'avoir écrire des commetaires")]
    public class WriterAuthentification : AdminBaseClass
    {
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
            _userAcceptanceTestApi.createUser(TestData.Writer1);
        }

        private void le_chroniqueur_entre_son_courriel_et_mot_de_passe_valide()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var loginPage = homePage.GoToLoginPage();
            loginPage.LoginAs(TestData.Writer1.Email, TestData.Writer1.Password);
        }
        private void le_chroniqueur_devrait_être_authentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.IsLogged(TestData.Writer1.Email);

            Assert.IsTrue(islogged);
        }

        private void le_chroniqueur_entre_un_mot_de_passe_invalide()
        {
            var loginPage = _homePage.GoToLoginPage();
            loginPage.LoginAs(TestData.Writer1.Email, "invalid_password");
        }

        private void le_chroniqueur_ne_devrait_pas_être_authentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.IsLogged(TestData.Writer1.Email);

            Assert.IsFalse(islogged);
        }
    }
}