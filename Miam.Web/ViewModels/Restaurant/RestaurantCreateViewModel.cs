using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Externalization;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.ViewModels.Restaurant
{
    public class RestaurantCreateViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(UiText.Restaurant.NAME)]
        [Required(ErrorMessage = UiText.Restaurant.NAME_REQUIRED_ERROR)]
        public string Name { get; set; }

        [DisplayName( UiText.Restaurant.CITY)]
        [Required(ErrorMessage = UiText.Restaurant.CITY_REQUIRED_ERROR)]
        public string City { get; set; }

        [DisplayName(UiText.Restaurant.COUNTRY)]
        [Required(ErrorMessage = UiText.Restaurant.COUNTRY_REQUIRED_ERROR)]
        public string Country { get; set; }

        public ContactDetailViewModel ContactDetailViewModel { get; set; }

    }
}