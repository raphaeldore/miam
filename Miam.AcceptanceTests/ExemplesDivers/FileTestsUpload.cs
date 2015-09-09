using System;
using Miam.AcceptanceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.ExemplesDivers
{
    // Scénarios et user story INCOMPLETS.  
    [TestClass]
    [Story(
       Title = "Un utilisateur peut télécharger un fichier sur le serveur",
       AsA = "En tant qu'utilisateur",
       IWant = "Je veux pouvoir télécharger un fichier sur le serveur",
       SoThat = "Afin de ...")]
    public class FileTestsUpload : AcceptanceTestsBaseClass
    {
        [TestMethod, Ignore]
        public void uploader_un_fichier()
        {
            this.Given(x => un_utilisateur_anonyme())
                .When(x => l_utilisateur_télécharge_un_fichier_sur_le_serveur())
                .Then(x => le_fichier_est_envoyé())
                .BDDfy();
        }

        private void un_utilisateur_anonyme()
        {

        }

        private void l_utilisateur_télécharge_un_fichier_sur_le_serveur()
        {
            throw new NotImplementedException();
            // Les fichiers de tests se trouvent dans le dossier TestFiles du projet Miam.Web.AcceptanceTests
            // Les fichiers sont téléchargés dans le dossier Uploads du projet Miam.Web  (voir méthode Upload du contrôleur File)

            // UploadPage.Goto();
            // UploadPage.UploadTestFile(TestData.WordFileName); //Voir les explications dans la méthode UploadTestFile


        }

        private void le_fichier_est_envoyé()
        {
            throw new NotImplementedException();
            // DownloadIndexPage.Goto();
            // Assert.IsTrue(DownloadIndexPage.DoesFileNameDisplayed(TestData.WordFileName));

        }
    }
}


