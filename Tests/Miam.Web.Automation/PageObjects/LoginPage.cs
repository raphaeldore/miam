using System;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Miam.Web.Automation.PageObjects
{
    public class LoginPage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("login-page"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static LoginCommand LoginAs(string email)
        {
            return new LoginCommand(email);
        }

      
        public static void GoTo()
        {
            Navigation.AllUsers.Login.Select();
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
