using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using Miam.ApplicationServices.Email;
using SendGrid;


namespace Miam.Web.Controllers
{
    public partial class EmailController : Controller
    {
        [HttpGet]
        public virtual ActionResult Send()
        {
            return View();
        }

        [HttpPost, ActionName("Send")]
        public virtual async Task<ActionResult> SendConfirmed()
        {
            //Todo: La classe ne devrait pas dépendre du service de EmailService, mais d'une interface injectée au constructeur.

            var emailService = new EmailService();

            var email = new MailMessage()
            {
                From = new MailAddress("miamadmin@yopmail.com", "Miam admin"),
                To = { new MailAddress("lindachampagne@yopmail.com", "Linda Champagne") },
                Subject = "Le sujet",
                Body = "Le message"

            };

            //Todo: Gérer les exceptions et envoyer un message à l'utlisateur si erreur lors de l'envoi.
            try
            {
                await emailService.SendMessage(email);
            }
            catch (Exception)
            {
                int a = 1;
                throw;
            }
            

            //Todo: une confirmation que le message a été envoyé devrait être ajouté

            return RedirectToAction("Send");
        }

        private async Task SendEmailExample()
        {
            // Todo: Gérer les exceptions 

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("Linda Champagne<lindachampagne@yopmail.com>");
            myMessage.From = new MailAddress("frommiamtest@yopmail.com", "Coordonateur de miam");
            myMessage.Subject = "le texte";
            myMessage.Text = "le message";

            var sendGridApi = ConfigurationManager.AppSettings["SendGridApi"];
            var transportWeb = new SendGrid.Web(sendGridApi);

            await transportWeb.DeliverAsync(myMessage);
        }
    }
}

