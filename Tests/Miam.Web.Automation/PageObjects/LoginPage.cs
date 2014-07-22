using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "/Account/Login");
        }

        public static LoginCommand LoginAs(string email)
        {
            return new LoginCommand(email);
        }
    }

    public class LoginCommand
    {
        private readonly string _email;
        private string _password;

        public LoginCommand(string email)
        {
            _email = email;
            
        }

        public LoginCommand WithPassowrd(string password)
        {
            _password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("Email"));
            loginInput.SendKeys(_email);

            var passwordInput = Driver.Instance.FindElement(By.Id("Password"));
            passwordInput.SendKeys(_password);

            var loginButton = Driver.Instance.FindElement(By.Id("login-submit"));
            loginButton.Click();

        }
    }
}
