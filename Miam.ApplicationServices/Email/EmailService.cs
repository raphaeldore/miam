using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;

namespace Miam.ApplicationServices.Email
{
    public class EmailService
    {
        public async Task SendMessage(MailMessage email)
        {
            //Todo: refactoriser
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
        }
    }
}