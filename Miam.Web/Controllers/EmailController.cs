﻿using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
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
        public virtual ActionResult SendConfirmed()
        {
            //Todo: un service devrait être créé pour l'envoi de courriel
            
            SendEmailExample();
            
            //Todo: une confirmation que le message a été envoyé devrait être ajouté

            return RedirectToAction("Send");
        }

        private async void SendEmailExample()
        {
            // Todo: Gérer les exceptions 

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("tomiamtest@yopmail.com");
            myMessage.From = new MailAddress("frommiamtest@yopmail.com", "Coordonateur de miam");
            myMessage.Subject = "le texte";
            myMessage.Text = "le message";

            //var accountSendGrid = ConfigurationManager.AppSettings["SendGridApi"];
            var transportWeb = new SendGrid.Web("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");

            await transportWeb.DeliverAsync(myMessage);
        }
    }
}

