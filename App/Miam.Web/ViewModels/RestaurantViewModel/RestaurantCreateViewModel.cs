using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Miam.Domain.Entities;

namespace Miam.Web.ViewModels.RestaurantViewModel
{
    public class RestaurantCreateViewModel
    {

        [HiddenInput]
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public RestaurantContactDetail RestaurantContactDetail { get; set; }

    }
}