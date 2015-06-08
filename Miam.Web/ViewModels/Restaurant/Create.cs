using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Miam.Domain.Entities;

namespace Miam.Web.ViewModels.Restaurant
{
    public class Create
    {

        [HiddenInput]
        public int RestaurantId { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le champ nom est requis")]
        public string Name { get; set; }

        [DisplayName("Ville")]
        [Required(ErrorMessage = "Le champ ville est requis")]
        public string City { get; set; }

        [DisplayName("Pays")]
        [Required(ErrorMessage = "Le champ pays est requis")]
        public string Country { get; set; }

        public RestaurantContactDetail RestaurantContactDetail { get; set; }

    }
}