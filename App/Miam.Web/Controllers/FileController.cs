using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miam.Web.Controllers
{
    public partial class FileController : Controller
    {
        [HttpGet]
        public virtual ActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public virtual ActionResult Upload(HttpPostedFileBase file)
        {
            // Exemple pour télécharger un fichier.
            // Voir le test d'acceptation user_can_upload_file de la classe UploadTests.
            // Voir fichier README.txt dans le dossier uplaods du projet miam.web
            if (file == null)
            {
                ModelState.AddModelError("fileError", "Fichier inexistant");
                return View("");
            }

            if (file.ContentLength <= 0)
            {
                ModelState.AddModelError("fileError", "Fichier vide");
                return View("");
            }

            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
            file.SaveAs(path);
            return RedirectToRoute(MVC.Home.Index());
            
        }

    }
}