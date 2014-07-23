using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Miam.Web.ViewModels.RestaurantViewModel
{
    public class RestaurantEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public string Name { get; set; }

        [DisplayName("Ville")]
        [Required(ErrorMessage = "Requis")]
        public string City { get; set; }

        [DisplayName("Pays")]
        [Required(ErrorMessage = "Requis")]
        public string Country { get; set; }
        public RestaurantContactDetailViewModel RestaurantContactDetail { get; set; }
        public List<ReviewIndexViewModel> Reviews { get; set; }

    }
}