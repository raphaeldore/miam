using System.ComponentModel;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Miam.Web.ViewModels.Restaurant;

namespace Miam.Web.ViewModels.Review
{
    [Validator(typeof(ReviewCreateViewModelValidator))]
    public class ReviewCreateViewModel
    {
        [DisplayName("Évaluation (1 à 5)")]
        public int Rating { get; set; }

        [DisplayName("Critique")]
        public string Body { get; set; }

        [HiddenInput]
        public int RestaurantId { get; set; }

        [DisplayName("Restaurant")]
        public SelectList Restaurants { get; set; }
    }
}