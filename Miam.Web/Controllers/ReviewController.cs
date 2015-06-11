using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.Controllers
{
    public partial class ReviewController : Controller
    {
        private readonly IEntityRepository<Review> _reviewRepository;
        private readonly IEntityRepository<Restaurant> _restaurantRepository;
        private readonly IHttpContextService _httpContextService;

        public ReviewController(IEntityRepository<Review> reviewRepository,
                                IEntityRepository<Restaurant> restaurantRepository,
                                IHttpContextService httpContextService)
        {

            if (reviewRepository == null) throw new NullReferenceException();
            if (restaurantRepository == null) throw new NullReferenceException();
            if (httpContextService == null) throw new NullReferenceException();

            _reviewRepository = reviewRepository;
            _restaurantRepository = restaurantRepository;
            _httpContextService = httpContextService;
        }

        [Authorize(Roles = RoleName.Writer)]
        public virtual ActionResult Create()
        {
            var model = new ReviewCreateViewModel();
            PopulateRestaurantSelectList(model);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Writer)]
        public virtual ActionResult Create(ReviewCreateViewModel reviewCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var review = Mappers.createReviewFrom(reviewCreateViewModel);
                review.WriterId = _httpContextService.GetUserId();

                _reviewRepository.Add(review);

                return RedirectToAction(MVC.Home.Index());
            }

            PopulateRestaurantSelectList(reviewCreateViewModel);
            return View(reviewCreateViewModel);
        }

        
        private void PopulateRestaurantSelectList(ReviewCreateViewModel model)
        {
            model.Restaurants = new SelectList(_restaurantRepository.GetAll(), "Id", "Name");
        }
    }
}