using System;
using System.IO;
using System.Web;

namespace Miam.ApplicationServices.File
{
    public class FileService
    {
        public void SaveFileToServer(HttpPostedFileBase httpPostFile)
        {
            var fileName = Path.GetFileName(httpPostFile.FileName);

            // AppDomain.CurrentDomain.GetData("DataDirectory") correspond au dossier app_data dans le dossier web.
            // Est initialisé par MVC.

            var path = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\uploads";
            path = Path.Combine(path, fileName);
            httpPostFile.SaveAs(path);
        }
    }
}