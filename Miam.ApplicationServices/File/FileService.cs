using System;
using System.IO;
using System.Web;

namespace Miam.ApplicationServices.File
{
    public class FileService
    {
        public void SaveFileToServer(HttpPostedFileBase httpPostFile)
        {
            //Todo: refactoriser
            //Todo: vérifier que le nom du fichier n'est pas vide ou null

            var fileName = Path.GetFileName(httpPostFile.FileName);

            var pathToSaveFile = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(),"uploads\\");

            if (!Directory.Exists(pathToSaveFile))
            {
                FileInfo file = new System.IO.FileInfo(pathToSaveFile);
                file.Directory.Create(); 
            }

            var pathToSaveWithFileName = Path.Combine(pathToSaveFile, fileName);
            httpPostFile.SaveAs(pathToSaveWithFileName);
        }
    }
}