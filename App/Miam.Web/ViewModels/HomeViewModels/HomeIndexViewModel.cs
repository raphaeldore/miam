using System.Collections.Generic;
using Miam.Web.ViewModels.RestaurantViewModel;

namespace Miam.Web.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float RatingReviewsAverage { get; set; }
        
    }
}