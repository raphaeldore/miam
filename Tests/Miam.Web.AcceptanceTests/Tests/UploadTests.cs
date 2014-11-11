using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.TestUtility.Database;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests.Tests
{
    [TestClass]
    public class UploadTests : MiamAcceptanceBaseClassTests
    {
        [TestMethod]
        public void user_can_upload_file()
        {
            // Les fichiers de tests se trouvent dans le dossier TestFiles du projet Miam.Web.AcceptanceTests
            // Les fichiers sont téléchargés dans le dossier Uploads du projet Miam.Web  (voir méthode Upload du contrôleur File)

            UploadPage.Goto();
 
            // Voir explication dans la méthode UploadTestFile ci-dessous
            UploadPage.UploadTestFile("exemple.docx");
            
            //Todo: Réécrie l'assertion du test lorsqu'il sera possible d'afficher la liste des fichiers téléchargés
            // Pour l'instant ne test que le retour à la page d'accueil.
            Assert.IsTrue(HomePage.HasRestaurant);


        }
    }
}
