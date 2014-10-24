using System.Net.Mail;
using System.Security.Claims;
using System.Web.Mvc;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Microsoft.AspNet.Identity;


namespace Miam.Web.Controllers
{
    public partial class EmailController : Controller
    {
        //Code incomplet, qui a pour but de montrer l'utilisation de smtp4dev.
        // - smtp4dev permet d'envoyer et recevoir des courriels en local (évite d'envoyer pour vrai les courriels lors du développement).
        // - Les tests d'acceptation exécutés en local utilisent smtp4dev. Aucun courriel ne sera envoyé.
        // - Les tests d'acceptation exécutés sur le serveur d'intégration (Jenkins) utilisent un vrai serveur SMTP. Les courriels sont réellement envoyés.
        //
        //Pour télécharger smpt4dev: https://smtp4dev.codeplex.com/
        //
        //Configuration en local: 
        //  Installer et exécuter smtp4dev
        //  Ajouter la ligne ci-dessous dans le fichier hosts  (C:\Windows\System32\drivers\etc\hosts):
        //  127.0.0.1 jenkinssmtp.cegep-ste-foy.qc.ca

        [HttpGet]
        public virtual ActionResult Send()
        {
            return View();
        }


        [HttpPost]
        public virtual ActionResult Send(Miam.Web.ViewModels.Email.SendEmail sendEmailViewModel)
        {
            MailMessage mail = new MailMessage(sendEmailViewModel.From, sendEmailViewModel.To);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "jenkinssmtp.cegep-ste-foy.qc.ca";
            mail.Subject = sendEmailViewModel.Subject;
            mail.Body = sendEmailViewModel.Body;
            client.Send(mail);

            return RedirectToRoute(MVC.Home.Index());
        }
    }
}

