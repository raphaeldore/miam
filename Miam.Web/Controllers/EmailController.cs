using System.Configuration;
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
            
            var a = SendEmailExample();
            
            //Todo: une confirmation que le message a été envoyé devrait être ajouté

            return RedirectToAction("Send");
        }

        private async Task SendEmailExample()
        {
            // Todo: Gérer les exceptions 

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("tomiamtest@yopmail.com");
            myMessage.From = new MailAddress("frommiamtest@yopmail.com", "Coordonateur de miam");
            myMessage.Subject = "le texte";
            myMessage.Text = "le message";

            var sendGridApi = ConfigurationManager.AppSettings["SendGridApi"];
            var transportWeb = new SendGrid.Web(sendGridApi);

            await transportWeb.DeliverAsync(myMessage);
        }
    }
}

