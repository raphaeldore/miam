
using System.Collections.Generic;

using AutoMapper;
using Miam.Domain.Entities;



using Create = Miam.Web.ViewModels;


namespace Miam.Web.Mappers
{
    class ViewModelToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToModelMappings"; }
        }

        protected override void Configure()
        {
            // Create ViewModel mapping
            Mapper.CreateMap<ViewModels.Restaurant.Create, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RestaurantId))
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            Mapper.CreateMap<ViewModels.Review.Create, Review>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore())
                .ForMember(dest => dest.Writer, opt => opt.Ignore())
                .ForMember(dest => dest.WriterId, opt => opt.Ignore());

            // Edit ViewModel mapping
            Mapper.CreateMap<List<ViewModels.Review.Index>, ICollection<Review>>();
            
            Mapper.CreateMap<ViewModels.Restaurant.ContactDetail, RestaurantContactDetail>()
                .ForMember(dest => dest.RestaurantId, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore());

            Mapper.CreateMap<ViewModels.Restaurant.Edit, Restaurant>()
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

        }
    }
}