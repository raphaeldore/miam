using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Domain.RoleName;
using Miam.Web.ViewModels.RestaurantViewModel;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public partial class RestaurantController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;

        public RestaurantController(IEntityRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }


        public virtual ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetAll().ToList();

            var restaurantIndexViewModels = Mapper.Map<IEnumerable<RestaurantIndexViewModel>>(restaurants);

            return View(restaurantIndexViewModels);
        }

        [HttpGet]
        public virtual ActionResult Edit(int restaurantID)
        {
            var restaurant = _restaurantRepository.GetById(restaurantID);

            if (restaurant != null)
            {
                var restaurantEditPageViewModel = Mapper.Map<RestaurantEditViewModel>(restaurant);
               
                return View(restaurantEditPageViewModel);
            }
            return HttpNotFound();
        }


        [HttpPost]
        public virtual ActionResult Edit(RestaurantEditViewModel restaurantEditViewModel)
        {
            var restaurant = _restaurantRepository.GetById(restaurantEditViewModel.Id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                restaurantEditViewModel.Reviews = Mapper.Map<List<ReviewIndexViewModel>>(restaurant.Reviews);
                return View(restaurantEditViewModel);
            }

            Mapper.Map(restaurantEditViewModel, restaurant);

            _restaurantRepository.Update(restaurant);

            return RedirectToAction(MVC.Restaurant.Index());
        }


        [HttpGet]
        public virtual ActionResult Delete(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);

            if (restaurant != null)
            {
                var restaurantViewModel = Mapper.Map<RestaurantDeleteViewModel>(restaurant);
                return View(restaurantViewModel);
            }
            return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);

            if (restaurant != null)
            {
                _restaurantRepository.Delete(restaurant);
                return RedirectToAction(MVC.Restaurant.Index());
            }

            return HttpNotFound();
            
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
