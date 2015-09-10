using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.ExemplesDivers
{
    // Todo: à compléter
    [TestClass]
    [Story(
       Title = "Un utilisateur peut télécharger un fichier sur le serveur",
       AsA = "En tant qu'utilisateur",
       IWant = "Je veux pouvoir télécharger un fichier sur le serveur",
       SoThat = "Afin de ...")]
    public class FileTestsUpload : BaseAcceptanceTests
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
            throw new NotImplementedException();
        }

        private void l_utilisateur_télécharge_un_fichier_sur_le_serveur()
        {
            throw new NotImplementedException();
        }

        private void le_fichier_est_envoyé()
        {
            throw new NotImplementedException();
        }
    }
}


