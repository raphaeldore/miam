using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.TestUtility.Database;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.PageObjects.FilePages;
using Miam.Web.Automation.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests.Tests
{
    [TestClass]
    public class FileTests : MiamAcceptanceBaseClassTests
    {
        [TestMethod]
        public void user_can_upload_file()
        {
            // Les fichiers de tests se trouvent dans le dossier TestFiles du projet Miam.Web.AcceptanceTests
            // Les fichiers sont téléchargés dans le dossier Uploads du projet Miam.Web  (voir méthode Upload du contrôleur File)

            UploadPage.Goto();

            // Voir les explications dans la méthode UploadTestFile ci-dessous
            UploadPage.UploadTestFile(TestData.WordFileName);

            //Assert
            DownloadIndexPage.Goto();
            Assert.IsTrue(DownloadIndexPage.DoesFileNameDisplayed(TestData.WordFileName));
        }
         
        [TestMethod]
        public void user_can_download_file()
        {
            //Arrange
            UploadPage.Goto();
            UploadPage.UploadTestFile(TestData.WordFileName);

            //Action
            DownloadIndexPage.Goto();
            DownloadIndexPage.ClickFile(TestData.WordFileName);
            //Ce test ne peut fonctionner que si FireFox n'ouvre pas de boite de dialogue.
            //Voir le code de la méthode Initialize et CreateSeleniumPorfile de la classe Driver (dossier Selenium du projet Web.Automation)
            //afin de voir comment indiquer à FireFox de ne pas ouvrir de boite de dialogue.

            //Assert
            Assert.IsTrue(DownloadIndexPage.IsDisplayed); //En cas d'erreur c'est une autre page qui est affichée


        }
    }
}

    
