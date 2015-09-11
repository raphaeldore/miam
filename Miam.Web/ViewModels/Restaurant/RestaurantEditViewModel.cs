using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Externalization;
using FluentValidation.Attributes;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Review;


namespace Miam.Web.ViewModels.Restaurant
{
    [Validator(typeof(RestaurantEditViewModelValidator))]
    public class RestaurantEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(UiText.Restaurant.NAME)]
        public string Name { get; set; }

        [DisplayName(UiText.Restaurant.CITY)]
        public string City { get; set; }

        [DisplayName(UiText.Restaurant.COUNTRY)]
        public string Country { get; set; }
        public ContactDetailViewModel ContactDetailViewModel { get; set; }
        public List<ReviewIndexViewModel> ReviewsViewModel { get; set; }

    }
}