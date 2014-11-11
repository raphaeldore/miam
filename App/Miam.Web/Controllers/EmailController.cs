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
        //Code incomplet, qui a pour but de montrer l'utilisation du serveur smtp de jenkins.
        // Lors du développement et pour tester en local, il est conseillé de ne pas envoyer les courriels au serveur smpt de jenkins. 
        // Pour y arriver, il faut installer un serveur smpt en local (smtp4dev)
        // - Les tests d'acceptation exécutés en local utiliseront smtp4dev. Aucun courriel ne sera vraiment envoyé.
        // - Les tests d'acceptation exécutés sur le serveur d'intégration (Jenkins) utiliseront un vrai serveur SMTP. Les courriels sont réellement envoyés.
        //
        //Pour télécharger smpt4dev: https://smtp4dev.codeplex.com/
        //
        //Configuration en local: 
        //  - Installer et exécuter smtp4dev
        //  - Ajouter la ligne ci-dessous dans le fichier hosts  (C:\Windows\System32\drivers\etc\hosts):
        //    127.0.0.1 jenkinssmtp.cegep-ste-foy.qc.ca

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

