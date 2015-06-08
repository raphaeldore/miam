using Miam.AcceptanceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.ExemplesDivers
{
    // Scénarios et user story INCOMPLETS.  
    [TestClass]
    [Story(
       Title = "Un utilisateur peut télécharger un fichier",
       AsA = "En tant qu'utilisateur",
       IWant = "Je veux pouvoir télécharger un fichier sur le serveur",
       SoThat = "Afin de ...")]
    public class FileTestsDownload : AcceptanceTestsBaseClass
    {
        [TestMethod]
        public void uploader_un_fichier()
        {
            this.Given(x => un_utilisateur_anonyme())
                .When(x => l_utilisateur_télécharge_un_fichier())
                .Then(x => le_fichier_est_envoyé())
                .BDDfy();
        }

        private void un_utilisateur_anonyme()
        {

        }

        private void l_utilisateur_télécharge_un_fichier()
        {
            throw new System.NotImplementedException();

            // UploadPage.Goto();
            // UploadPage.UploadTestFile(TestData.WordFileName);

            // DownloadIndexPage.Goto();
            // DownloadIndexPage.ClickFile(TestData.WordFileName);
            // //Ce test ne peut fonctionner que si FireFox n'ouvre pas de boite de dialogue.
            // //Voir comment indiquer à FireFox de ne pas ouvrir de boite de dialogue avec l'utlisation d'un profile
            // //dans les méthodes Initialize et CreateSeleniumProfile de la classe Driver (dossier Selenium du projet Web.Automation)



        }

        private void le_fichier_est_envoyé()
        {
            throw new System.NotImplementedException();
            // //En cas d'erreur, une page autre que DownloadIndex sera affichée. 
            // //Donc s'il n'y a pas d'erreur, la page affichée est DownloadIndex.
            // Assert.IsTrue(DownloadIndexPage.IsDisplayed); 
        }
    }
}
