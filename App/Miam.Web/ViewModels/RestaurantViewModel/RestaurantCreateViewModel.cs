using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Miam.Domain.Entities;

namespace Miam.Web.ViewModels.RestaurantViewModel
{
    public class RestaurantCreateViewModel
    {

        [HiddenInput]
        public int RestaurantId { get; set; }
        [Required(ErrorMessage = "Le champ nom est requis")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le champ ville est requis")]
        public string City { get; set; }
        [Required(ErrorMessage = "Le champ pays est requis")]
        public string Country { get; set; }

        public RestaurantContactDetail RestaurantContactDetail { get; set; }

    }
}