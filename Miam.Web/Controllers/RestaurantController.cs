using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Mappers;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public partial class RestaurantController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;
        private RestaurantViewModelMapper _mappersRestaurantViewModel;

        public RestaurantController(IEntityRepository<Restaurant> restaurantRepository)
        {
            if (restaurantRepository == null) throw new NullReferenceException();

            _restaurantRepository = restaurantRepository;

            _mappersRestaurantViewModel = new RestaurantViewModelMapper();
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
                var restaurantEditPageViewModel = _mappersRestaurantViewModel.Map(restaurant);

                return View(restaurantEditPageViewModel);
            }
            return HttpNotFound();
        }

        


        [HttpPost]
        public virtual ActionResult Edit(RestaurantViewModel restaurantViewModel)
        {
            var restaurant = _restaurantRepository.GetById(restaurantViewModel.Id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                restaurantViewModel.ReviewsViewModel = createReviewsFrom(restaurant.Reviews);
                return View(restaurantViewModel);
            }

            MappersSimple.UpdateRestaurantFromViewModel(restaurant, restaurantViewModel);

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
        public virtual ActionResult Create(RestaurantViewModel restaurantViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurant = MappersSimple.CreateRestaurantFrom(restaurantViewModel);
                _restaurantRepository.Add(restaurant);
                return RedirectToAction(Views.ViewNames.Index);
            }
            return View("");
        }

       
    }
}
