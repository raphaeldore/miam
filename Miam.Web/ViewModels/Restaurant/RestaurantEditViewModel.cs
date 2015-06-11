using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Review;


namespace Miam.Web.ViewModels.Restaurant
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
        public ContactDetailViewModel RestaurantContactDetailViewModel { get; set; }
        public List<ReviewIndexViewModel> ReviewsViewModel { get; set; }

    }
}