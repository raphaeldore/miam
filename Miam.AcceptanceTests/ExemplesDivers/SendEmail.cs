using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Web.AcceptanceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.ExemplesDivers
{
    // Scénarios et user story INCOMPLETS. Exemple pour montrer un test d'acceptation pour l'envoi d'un courriel. 
    [TestClass]
    [Story(
        Title = "Un utilisateur peut envoyer un courriel",
        AsA = "En tant qu'utilisateur",
        IWant = "Je veux pouvoir envoyer un courriel",
        SoThat = "Afin de ...")]
    public class SendEmail : AcceptanceTestsBaseClass
    {
        [TestMethod]
        public void envoyer_un_courriel()
        {
            this.Given(x => un_utilisateur_anonyme())
                .When(x => l_utilisateur_envoie_un_courriel())
                .Then(x => le_courriel_est_envoyé())
                .BDDfy();
        }

        private void un_utilisateur_anonyme()
        {
        }

        private void l_utilisateur_envoie_un_courriel()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .GoToEmailPage()
                .SendEamil();
        }

        private void le_courriel_est_envoyé()
        {
            //Todo: Vérifier le message de confirmation
            throw new System.NotImplementedException();
        }
    }
}
