using System.Web.Mvc;

namespace Miam.Web.ViewModels.Restaurant
{
    public class Index
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