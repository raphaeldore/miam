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
        // - smtp4dev permet d'envoyer et recevoir des courriels sur son poste de travail sans avoir a configuer un serveur SMTP
        // - Les tests d'acceptation executés en local utilisent smtp4dev.
        // - Les tests d'acceptation executés sur le serveur d'integration (Jenkins) utilisent un vrai serveur SMTP.
        //
        //Pour télécharger smpt4dev: https://smtp4dev.codeplex.com/

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
            client.Host = "localhost";
            mail.Subject = sendEmailViewModel.Subject;
            mail.Body = sendEmailViewModel.Body;
            client.Send(mail);

            return RedirectToRoute(MVC.Home.Index());
        }
    }
}

