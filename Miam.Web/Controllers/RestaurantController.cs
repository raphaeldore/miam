using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Mappers;
using Miam.Web.Mappers.Restaurant;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public partial class RestaurantController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;
        private MapperRestaurantCreateViewModel _mapperRestaurantCreateViewModel;

        public RestaurantController(IEntityRepository<Restaurant> restaurantRepository)
        {
            if (restaurantRepository == null) throw new NullReferenceException();

            _restaurantRepository = restaurantRepository;

            _mapperRestaurantCreateViewModel = new MapperRestaurantCreateViewModel();
        }


        public virtual ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetAll().ToList();

            var restaurantIndexViewModels = MappersSimple.CreateRestaurantIndexViewModelFrom(restaurants);

            return View(restaurantIndexViewModels);
        }

        

        [HttpGet]
        public virtual ActionResult Edit(int restaurantID)
        {
            var restaurant = _restaurantRepository.GetById(restaurantID);

            if (restaurant != null)
            {
                var restaurantEditPageViewModel = _mapperRestaurantCreateViewModel.Map(restaurant);

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
                restaurantEditViewModel.ReviewsViewModel = createReviewsFrom(restaurant.Reviews);
                return View(restaurantEditViewModel);
            }

            MappersSimple.UpdateRestaurantFromViewModel(restaurant, restaurantEditViewModel);

            _restaurantRepository.Update(restaurant);

            return RedirectToAction(Views.ViewNames.Index);
        }

        private List<ReviewIndexViewModel> createReviewsFrom(ICollection<Review> reviews)
        {
            var reviewsIndexViewModel = reviews
                .Select(x => new ReviewIndexViewModel
                {
                    Body = x.Body,
                    Rating = x.Rating,
                    WriterName = x.Writer.Name
                }).ToList();

            return reviewsIndexViewModel;
        }


        [HttpGet]
        public virtual ActionResult Delete(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);

            if (restaurant != null)
            {
                var restaurantViewModel = MappersSimple.CreateRestaurantDeleteViewModelFrom(restaurant);
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
        public virtual ActionResult Create(RestaurantCreateViewModel restaurantCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurant = MappersSimple.CreateRestaurantFrom(restaurantCreateViewModel);
                _restaurantRepository.Add(restaurant);
                return RedirectToAction(Views.ViewNames.Index);
            }
            return View("");
        }

       
    }
}
