using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Index = Miam.Web.ViewModels.Review.Index;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public partial class RestaurantController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;

        public RestaurantController(IEntityRepository<Restaurant> restaurantRepository)
        {
            if (restaurantRepository == null) throw new NullReferenceException();

            _restaurantRepository = restaurantRepository;
        }


        public virtual ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetAll().ToList();

            var restaurantIndexViewModels = Mapper.Map<IEnumerable<ViewModels.Restaurant.Index>>(restaurants);

            return View(restaurantIndexViewModels);
        }

        [HttpGet]
        public virtual ActionResult Edit(int restaurantID)
        {
            var restaurant = _restaurantRepository.GetById(restaurantID);

            if (restaurant != null)
            {
                var restaurantEditPageViewModel = Mapper.Map<ViewModels.Restaurant.Edit>(restaurant);
               
                return View(restaurantEditPageViewModel);
            }
            return HttpNotFound();
        }


        [HttpPost]
        public virtual ActionResult Edit(ViewModels.Restaurant.Edit editRestaurantViewModel)
        {
            var restaurant = _restaurantRepository.GetById(editRestaurantViewModel.Id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                editRestaurantViewModel.Reviews = Mapper.Map<List<Index>>(restaurant.Reviews);
                return View(editRestaurantViewModel);
            }

            Mapper.Map(editRestaurantViewModel, restaurant);

            _restaurantRepository.Update(restaurant);

            return RedirectToAction(Views.ViewNames.Index);
        }


        [HttpGet]
        public virtual ActionResult Delete(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);

            if (restaurant != null)
            {
                var restaurantViewModel = Mapper.Map<ViewModels.Restaurant.Delete>(restaurant);
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
                return RedirectToAction(Views.ViewNames.Index);
            }

            return HttpNotFound();
            
        }

        public virtual ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModels.Restaurant.Create restaurantViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurant = Mapper.Map<Restaurant>(restaurantViewModel);
                _restaurantRepository.Add(restaurant);
                return RedirectToAction(Views.ViewNames.Index);
            }
            return View("");
        }
    }
}
