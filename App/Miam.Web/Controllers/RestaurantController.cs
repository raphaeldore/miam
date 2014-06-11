using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain;
using Miam.Domain.Entities;
using Miam.Domain.RoleName;
using Miam.Web.ViewModels.RestaurantViewModel;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.RegistredUser)]
    public partial class RestaurantController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;


        public RestaurantController(IEntityRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public virtual ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(RestaurantCreateViewModel restaurantCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurant = Mapper.Map<Restaurant>(restaurantCreateViewModel);
                _restaurantRepository.Add(restaurant);
                return RedirectToAction(MVC.Home.Index());
            }

            return View("");
        }

    }
}
