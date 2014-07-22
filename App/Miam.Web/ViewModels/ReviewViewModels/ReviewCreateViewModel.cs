using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Miam.Domain.Entities;

namespace Miam.Web.ViewModels.ReviewViewModels
{
    public class ReviewCreateViewModel
    {
        [Required(ErrorMessage = "Le champ évaluation est requis")]
        [Range(1, 5, ErrorMessage = "Le champ évaluation doit être compris entre 1 et 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Le champ critique est requis")]
        [StringLength(1024, ErrorMessage = "Le champ critique doit contenir moins de 1024 caractères")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Le champ restaurant est requis")]
        [HiddenInput]
        public int RestaurantId { get; set; }
        public SelectList Restaurants { get; set; }


    }
}