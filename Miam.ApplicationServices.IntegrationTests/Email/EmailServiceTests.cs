using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Miam.ApplicationServices.Email;
using Miam.TestUtility.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.ApplicationServices.IntegrationTests
{
    // DeploymentItem copie le fichier AppSettingsSecrets.config avec le DLL des tests d'integrations. 
    // Fichier nécessaire lors de l'execution avec Jenkins
    // App.config, fait référence à ce fichier.
    [DeploymentItem("AppSettingsSecrets.config")]

    [TestClass]
    public class UnitTest1
    {

        //Todo: refactoriser
        [TestMethod]
        public async Task Send_email_should_not_throw_any_exceptions()
        {
            //Arrange
            var emailService = new EmailService();

            var email = new MailMessage()
            {
                From = new MailAddress("miamadmin@yopmail.com","Miam admin"),
                To = { new MailAddress("lindachampagne@yopmail.com","Linda Champagne") },
                Subject = "Le sujet",
                Body = "Le message"

            };

            //Action
            await emailService.SendMessage(email);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void Send_email_without_from_address_should_throw_an_exception()
        {
            //Arrange
            var emailService = new EmailService();

            var email = new MailMessage()
            {
                From = new MailAddress("", "Miam admin"),
                To = { new MailAddress("lindachampagne@yopmail.com", "Linda Champagne") },
                Subject = "Le sujet",
                Body = "Le message"

            };

            //Action
            var asyncEmail = emailService.SendMessage(email);

        }
    }
}
