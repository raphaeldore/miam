
using System.Collections.Generic;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.Mappers
{
    class MappersReviewToEntity : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ReviewCreateViewModel, Review>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore())
                  .ForMember(dest => dest.Restaurant, opt => opt.Ignore())
                  .ForMember(dest => dest.Writer, opt => opt.Ignore())
                  .ForMember(dest => dest.WriterId, opt => opt.Ignore());
        }
    }
}