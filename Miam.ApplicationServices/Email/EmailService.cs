using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;

namespace Miam.ApplicationService.IntegrationTests
{
    public class EmailService
    {
        public async Task SendMessage(MailMessage email)
        {
            SendGridMessage sendGridMessage = new SendGridMessage();

            foreach (var toMailAddress in email.To)
            {
                sendGridMessage.AddTo(toMailAddress.User + "<" + toMailAddress.Address + ">");
            }
            sendGridMessage.From = email.From;
            sendGridMessage.Subject = email.Subject;
            sendGridMessage.Text = email.Body;

            var sendGridApi = ConfigurationManager.AppSettings["SendGridApi"];
            var transportWeb = new SendGrid.Web(sendGridApi);

            await transportWeb.DeliverAsync(sendGridMessage);

            //SendGridMessage myMessage = new SendGridMessage();
            //myMessage.AddTo("Linda Champagne<lindachampagne@yopmail.com>");
            //myMessage.From = new MailAddress("frommiamtest@yopmail.com", "Coordonateur de miam");
            //myMessage.Subject = "le texte";
            //myMessage.Text = "le message";

            ////var sendGridApi = "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";
            ////var transportWeb = new SendGrid.Web(sendGridApi);

            //await transportWeb.DeliverAsync(myMessage);
        }
    }
}