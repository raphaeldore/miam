using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Miam.Web.ViewModels.RestaurantViewModel
{
    public class RestaurantEditViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Le champ nom est requis")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le champ ville est requis")]
        public string City { get; set; }
        [Required(ErrorMessage = "Le champ pays est requis")]
        public string Country { get; set; }
        public RestaurantContactDetailViewModel RestaurantContactDetail { get; set; }
        public List<ReviewIndexViewModel> Reviews { get; set; }

    }
}