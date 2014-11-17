using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miam.Web.Automation.PageObjects.FilePages
{
    public class FileBasePage
    {
        protected static string GetFullPath(string filename)
        {
            var towFoldersUp = Path.GetFullPath("../../");

            var testFilesPath = Directory.GetDirectories(towFoldersUp, "TestFiles", SearchOption.AllDirectories)
                                         .FirstOrDefault();
            
            var fullPath = Path.Combine(testFilesPath, filename);
            
            return fullPath;
        }
    }
}
