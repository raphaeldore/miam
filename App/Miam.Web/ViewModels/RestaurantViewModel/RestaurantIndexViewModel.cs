using System.Web.Mvc;

namespace Miam.Web.ViewModels.RestaurantViewModel
{
    public class RestaurantIndexViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CountOfReviews { get; set; }
        public float RatingReviewsAverage { get; set; }

    }
}