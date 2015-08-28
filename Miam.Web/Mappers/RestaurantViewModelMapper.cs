using Miam.Domain.Entities;
using Miam.Web.ViewModels.Restaurant;

namespace Miam.Web.Mappers
{
    public class RestaurantViewModelMapper : IMapToNew<Restaurant, RestaurantViewModel>
    {
        public RestaurantViewModel Map(Restaurant source)
        {
            var target = new RestaurantViewModel
            {
                Id = source.Id,
                City = source.City,
                Country = source.Country,
                Name = source.Name,
                ContactDetailViewModel = MappersSimple.CreateContactDetailViewModelFrom(source.RestaurantContactDetail),
                ReviewsViewModel = MappersSimple.CreateReviewViewModelFrom(source.Reviews)
            };
            return target;
        }
    }
}