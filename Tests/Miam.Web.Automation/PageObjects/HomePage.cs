using System;
using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using Miam.Web.Automation.Seleno;
using Miam.Web.Controllers;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects
{
    public class HomePage : Page
    {
        // Seleno
        public LoginPage GoToLoginPage()
        {
            return Navigate.To<LoginPage>(By.Id("login-link"))
;       }

        public bool SelenoIsLogged(string email)
        {

            var navigationMenu = Find.Element(By.ClassName("navbar"));
            return navigationMenu.Text.Contains(email);
        }

        public void LogOut()
        {
            Host.Instance.NavigateToInitialPage<AccountController, LoginPage>(x => x.Logout());
            //var navigationMenu = Find.Element(By.ClassName("navbar"));
            //if (navigationMenu.Text.Contains("logout-link"))
            //    return Navigate.To<LoginPage>(By.Id("logout-link"));

            //return Navigate.To<LoginPage>();
        }

        public bool IsAUserConnected()
        {
            throw new NotImplementedException();
        }
        
        // Avant 
        private static int _lastCount;
        public static bool IsAdminLogged
        {
            get
            {
                var body = Driver.Instance.FindElement(By.ClassName("navbar"));
                return body.Text.Contains("Admin");
            } 
        }
        public static bool IsWriterLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("writer-menu"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public static bool HasRestaurant
        {
            get
            {
                return GetRestaurantCount() > 0; 
            }
        }

        public static int PreviousRestaurantCount
        {
            get { return _lastCount; }
        }
        public static void StoreRestaurtantCount()
        {
            _lastCount = GetRestaurantCount();
        }
        public static int CurrentRestaurantCount
        {
            get { return GetRestaurantCount(); }
        }
        private static int GetRestaurantCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("restaurants-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesRestaurantNameExist(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.ClassName("list-group"));
            return body.Text.Contains(textToFind);
        }

        public static void GoTo()
        {
            Navigation.AllUsers.Home.Select();
        }


        
    }
}
