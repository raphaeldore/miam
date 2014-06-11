using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain;
using Miam.Domain.Entities;
using Miam.Domain.RoleName;
using Miam.Web.ViewModels.AdminViewModels;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public partial class AdminController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;
        private readonly IEntityRepository<Review> _reviewRepository;

        public AdminController(IEntityRepository<Restaurant> restaurantRepository,
                                         IEntityRepository<Review> reviewRepository)
        {
            _restaurantRepository = restaurantRepository;
            _reviewRepository = reviewRepository;
        }

        public virtual ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetAll().ToList();

            var restaurantIndexViewModels = Mapper.Map<IEnumerable<AdminRestaurantIndexViewModel>>(restaurants);

            return View(restaurantIndexViewModels);
        }

        [HttpGet]
        public virtual ActionResult EditRestaurant(int restaurantID)
        {
            var restaurant = _restaurantRepository.GetById(restaurantID);

            if (restaurant != null)
            {
                var restaurantViewModel = Mapper.Map<AdminRestaurantEditViewModel>(restaurant);
                return View(restaurantViewModel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult EditRestaurant(AdminRestaurantEditViewModel adminRestaurantEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(adminRestaurantEditViewModel);
            }

            var restaurant = _restaurantRepository.GetById(adminRestaurantEditViewModel.Id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            Mapper.Map(adminRestaurantEditViewModel, restaurant);

            _restaurantRepository.Update(restaurant);
            return RedirectToAction(MVC.Admin.Index());

        }

        [HttpGet]
        public virtual ActionResult DeleteRestaurant(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);

            if (restaurant != null)
            {
                var restaurantViewModel = Mapper.Map<AdminRestaurantDeleteViewModel>(restaurant);
                return View(restaurantViewModel);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("DeleteRestaurant")]
        public virtual ActionResult DeleteRestaurantConfirmed(int restaurantId)
        {
            _restaurantRepository.DeleteById(restaurantId);
            return RedirectToAction(MVC.Admin.Index());
        }


        [HttpGet]
        public virtual ActionResult DeleteReview(int reviewId)
        {
            var review = _reviewRepository.GetById(reviewId);
            _reviewRepository.Delete(review);
            return RedirectToAction(MVC.Admin.EditRestaurant(review.RestaurantId));
        }

    }
}
