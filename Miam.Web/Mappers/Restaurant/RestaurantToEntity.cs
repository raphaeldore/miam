
using System.Collections.Generic;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Restaurant;

namespace Miam.Web.Mappers
{
    class MappersRestaurantToEntity : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<ViewModels.Restaurant.Create, Restaurant>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RestaurantId))
            //    .ForMember(dest => dest.Reviews, opt => opt.Ignore())
            //    .ForMember(dest => dest.Tags, opt => opt.Ignore());

            // même résultat que la ligne ci-dessus. IgnoreAllNonExisting fait partie de la classe MappingExpressionExtensions
            Mapper.CreateMap<RestaurantCreateViewModel, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .IgnoreAllNonExisting();


            Mapper.CreateMap<RestaurantEditViewModel, Restaurant>()
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.RestaurantContactDetail, opt => opt.MapFrom(src => src.ContactDetailViewModel));
        }
    }
}