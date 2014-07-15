using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Miam.Web.Automation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://miam.local/Account/Login");
           
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

            var loginButton = Driver.Instance.FindElement(By.Id("login_submit"));
            loginButton.Click();

        }
    }
}
