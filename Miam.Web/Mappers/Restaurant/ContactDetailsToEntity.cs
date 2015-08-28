
using System.Collections.Generic;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Restaurant;

namespace Miam.Web.Mappers
{
    class MappersContactDetailsToEntity : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContactDetailViewModel, RestaurantContactDetail>()
                  .ForMember(dest => dest.RestaurantId, opt => opt.Ignore())
                  .ForMember(dest => dest.Restaurant, opt => opt.Ignore());

        }
    }
}