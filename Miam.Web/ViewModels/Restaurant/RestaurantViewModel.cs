using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Externalization;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.ViewModels.Restaurant
{
    public class RestaurantViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(RestaurantsMessages.NAME_LABEL)]
        [Required(ErrorMessage = RestaurantsMessages.NAME_REQUIRED_ERROR)]
        public string Name { get; set; }

        [DisplayName( RestaurantsMessages.CITY_LABEL)]
        [Required(ErrorMessage = RestaurantsMessages.CITY_REQUIRED_ERROR)]
        public string City { get; set; }

        [DisplayName(RestaurantsMessages.COUNTRY_LABEL)]
        [Required(ErrorMessage = RestaurantsMessages.COUNTRY_REQUIRED_ERROR)]
        public string Country { get; set; }

        public ContactDetailViewModel ContactDetailViewModel { get; set; }
        public List<ReviewIndexViewModel> ReviewsViewModel { get; set; }

    }
}