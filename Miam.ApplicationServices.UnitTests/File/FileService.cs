using System;
using System.Web;
using Miam.ApplicationServices.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Miam.ApplicationServices.UnitTests.File
{
    [TestClass]
    public class FileServiceTests
    {

        //Todo: refactoriser

        [TestMethod]
        public void SaveFileToServer_should_save_file_to_upload_path()
        {
            //Arrange
            var fileService = new FileService();

            AppDomain.CurrentDomain.SetData("DataDirectory","");
            const  string FILE_NAME = "LoremIpsum.pdf";
            var savingPath = "\\uploads\\" + FILE_NAME;
            
            var mockHttpPostFile = Substitute.For<HttpPostedFileBase>();
            mockHttpPostFile.FileName.Returns(FILE_NAME);

            //Action
            fileService.SaveFileToServer(mockHttpPostFile);

            //Assert 
            mockHttpPostFile.Received().SaveAs(Arg.Is<String>(x => x.ToString() == savingPath));
        }
        public void downloadFileFromServer_should_save_file_to_upload_path()
        {
            //Arrange
            var fileService = new FileService();

            AppDomain.CurrentDomain.SetData("DataDirectory", "");
            const string FILE_NAME = "LoremIpsum.pdf";
            var savingPath = "\\uploads\\" + FILE_NAME;

            var mockHttpPostFile = Substitute.For<HttpPostedFileBase>();
            mockHttpPostFile.FileName.Returns(FILE_NAME);

            //Action
            fileService.SaveFileToServer(mockHttpPostFile);

            //Assert 
            mockHttpPostFile.Received().SaveAs(Arg.Is<String>(x => x.ToString() == savingPath));
        }
    }

  

}
