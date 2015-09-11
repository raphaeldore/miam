using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Externalization;
using FluentValidation.Attributes;
using Miam.Web.ViewModels.Account;

namespace Miam.Web.ViewModels.Restaurant
{
    [Validator(typeof(RestaurantCreateViewModelValidator))]
    public class RestaurantCreateViewModel 
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(UiText.Restaurant.NAME)]
        public string Name { get; set; }

        [DisplayName( UiText.Restaurant.CITY)]
        public string City { get; set; }

        [DisplayName(UiText.Restaurant.COUNTRY)]
        public string Country { get; set; }
        public ContactDetailViewModel ContactDetailViewModel { get; set; }
    }

}