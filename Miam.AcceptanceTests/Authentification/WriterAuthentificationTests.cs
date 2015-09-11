using FluentAssertions;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.TestUtility.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;
using Miam.Domain.Entities;

namespace Miam.AcceptanceTests.Authentification
{
    [TestClass]
    [Story(
        Title = "Un chroniqueur peut s'authentifier",
        AsA = "En tant que chroniqueur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin de pouvoir écrire des commetaires")]
    public class WriterAuthentificationTests : BaseAcceptanceTests
    {
        private Domain.Entities.Writer _writer;

        [TestMethod]
        public void s_authentifier_avec_courriel_et_mot_de_passe_valide()
        {
            this.Given(x => un_chroniqueur_existant_non_authentifé())
                .When(x => le_chroniqueur_entre_son_courriel_et_mot_de_passe_valide())
                .Then(x => le_chroniqueur_devrait_être_authentifié())
                .BDDfy();
        }

        private void un_chroniqueur_existant_non_authentifé()
        {
            _writer = TestData.Writer1;
            DbTestHelper.Users.Add(_writer);
        }

        private void le_chroniqueur_entre_son_courriel_et_mot_de_passe_valide()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            homePage
                .NavigationMenu
                .ClickLogin()
                .LoginAs(_writer.Email, _writer.Password);
        }
        private void le_chroniqueur_devrait_être_authentifié()
        {
            var loggedInUserName = Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .LoggedInUserName;

            loggedInUserName.ShouldBeEquivalentTo(_writer.Email);
        }

      
    }
}