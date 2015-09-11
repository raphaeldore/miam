using System;
using System.IO;
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
            const string FILE_NAME = "LoremIpsum.pdf";

            var mockHttpPostFile = Substitute.For<HttpPostedFileBase>();
            mockHttpPostFile.FileName.Returns(FILE_NAME);

            var expectedPathWithFileName = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(),"uploads\\",FILE_NAME);
            //Action
            fileService.SaveFileToServer(mockHttpPostFile);

            //Assert 
            mockHttpPostFile.Received().SaveAs(Arg.Is<String>(x => x.ToString() == expectedPathWithFileName));
        }
    }
}
