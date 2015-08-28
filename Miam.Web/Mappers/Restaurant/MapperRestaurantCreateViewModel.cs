using Miam.Web.ViewModels.Restaurant;

namespace Miam.Web.Mappers.Restaurant
{
    public class MapperRestaurantCreateViewModel : IMapToNew<Domain.Entities.Restaurant, RestaurantCreateViewModel>
    {
        public RestaurantCreateViewModel Map(Domain.Entities.Restaurant source)
        {
            var target = new RestaurantCreateViewModel
            {
                Id = source.Id,
                City = source.City,
                Country = source.Country,
                Name = source.Name,
                ContactDetailViewModel = MappersSimple.CreateContactDetailViewModelFrom(source.RestaurantContactDetail),
            };
            return target;
        }
    }
}