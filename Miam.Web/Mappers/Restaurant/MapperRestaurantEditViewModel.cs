using Miam.Web.ViewModels.Restaurant;

namespace Miam.Web.Mappers.Restaurant
{
    public class MapperRestaurantEditViewModel : IMapToNew<Domain.Entities.Restaurant, RestaurantEditViewModel>
    {
        public RestaurantEditViewModel Map(Domain.Entities.Restaurant source)
        {
            var target = new RestaurantEditViewModel
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