using System.Collections.Generic;
using System.Web.Mvc;

namespace Miam.Web.ViewModels.AdminViewModels
{
    public class AdminRestaurantEditViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public RestaurantConactDetailViewModel RestaurantContactDetail { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }

        //public AdminRestaurantEditViewModel()
        //{
        //    Reviews = new List<ReviewViewModel>();
        //}

    }
}