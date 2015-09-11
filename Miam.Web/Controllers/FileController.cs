using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public virtual ActionResult Index()
        {
            var uploadDirectory = Server.MapPath("~/uploads");
            var filesFullPath = Directory.GetFiles(uploadDirectory, "*.docx");

            return View(filesFullPath);

        }

        [HttpPost]
        public virtual ActionResult Upload(HttpPostedFileBase file)
        {
            //Todo: un service devrait être créé pour l'envoi de fichier
            //Todo: Gérer les exceptions

            // Exemple pour télécharger un fichier sur le serveur
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
            return RedirectToAction(MVC.Home.Index());
            
        }

        [HttpGet]
        public virtual ActionResult Download(string fullPathFileName)
        {
            //Todo: un service devrait être utlisé
            //Todo: Gérer les exceptions
            
            //Methode appelée par /File/Index
            // Exemple pour démontrer le téléchargement d'un fichier du serveur au poste client
            // Dans cet exemple le chemin complet est utilisé comme paramètre. Devrait être un id unique. 


            if (!System.IO.File.Exists(fullPathFileName))
            {
                return HttpNotFound();
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPathFileName);
            string fileName = Path.GetFileName(fullPathFileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}