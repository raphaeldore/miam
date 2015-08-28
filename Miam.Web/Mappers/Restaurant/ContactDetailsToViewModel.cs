
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;


namespace Miam.Web.Mappers
{
    public class MappersContactDetailsToViewModel : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RestaurantContactDetail, ContactDetailViewModel>();
        }
    }
}