using Miam.Domain.Entities;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages
{
    public class EditRestaurantPage : Page
    {
        public void DeleteFisrtRestaurant()
        {
            var deleteButton = Find.Element(By.CssSelector("a[id*='delete_button']"));
            deleteButton.Click();

            var confirmButton = Find.Element(By.TagName("input"));
            confirmButton.Click();
        }

        public void EditFisrtRestaurantWith(Restaurant newRestaurant)
        {
            Find.Element(By.CssSelector("a[id*='edit_button']")).Click();
            ClearAllRestaurantFields();
            FillAllRestaurantFieldsWith(newRestaurant);
            Find.Element(By.Id("submit_button")).Click();
        }

        private void FillAllRestaurantFieldsWith(Restaurant newRestaurant)
        {
            //Todo: éviter les "magical strings". 
            //Solution: utiliser le texte des libellés pour aller écrire dans la zone de texte. 
            //Implique que les libellés se retrouvent dans une fichier de constantes.
            //Utiliser la constante pour rechercher dans la page
            Find.Element(By.Id("Name")).SendKeys(newRestaurant.Name);
            Find.Element(By.Id("City")).SendKeys(newRestaurant.City);
            Find.Element(By.Id("Country")).SendKeys(newRestaurant.Country);
            Find.Element(By.Id("RestaurantContactDetailViewModel_FaxPhone")).SendKeys(newRestaurant.RestaurantContactDetail.FaxPhone);
            Find.Element(By.Id("RestaurantContactDetailViewModel_OfficePhone")).SendKeys(newRestaurant.RestaurantContactDetail.OfficePhone);
            Find.Element(By.Id("RestaurantContactDetailViewModel_TwitterAlias")).SendKeys(newRestaurant.RestaurantContactDetail.TwitterAlias);
            Find.Element(By.Id("RestaurantContactDetailViewModel_Facebook")).SendKeys(newRestaurant.RestaurantContactDetail.Facebook);
            Find.Element(By.Id("RestaurantContactDetailViewModel_WebPage")).SendKeys(newRestaurant.RestaurantContactDetail.WebPage);
        }

        private void ClearAllRestaurantFields()
        {
            //Todo: éviter les "magical strings". 
            //voir commentaire ci-dessus
            Find.Element(By.Id("Name")).Clear();
            Find.Element(By.Id("City")).Clear();
            Find.Element(By.Id("Country")).Clear();
            Find.Element(By.Id("RestaurantContactDetailViewModel_FaxPhone")).Clear();
            Find.Element(By.Id("RestaurantContactDetailViewModel_OfficePhone")).Clear();
            Find.Element(By.Id("RestaurantContactDetailViewModel_TwitterAlias")).Clear();
            Find.Element(By.Id("RestaurantContactDetailViewModel_Facebook")).Clear();
            Find.Element(By.Id("RestaurantContactDetailViewModel_WebPage")).Clear();
        }
    }
}