using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Review;
using Microsoft.AspNet.Identity;

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
            _reviewRepository = reviewRepository;
            _restaurantRepository = restaurantRepository;
            _httpContextService = httpContextService;
        }

        [Authorize(Roles = RoleName.Writer)]
        public virtual ActionResult Create()
        {
            var model = new ViewModels.Review.Create();
            PopulateRestaurantSelectList(model);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Writer)]
        public virtual ActionResult Create(ViewModels.Review.Create create)
        {
            if (ModelState.IsValid)
            {
                var review = Mapper.Map<Review>(create);
                review.WriterId = _httpContextService.GetUserId();

                _reviewRepository.Add(review);

                return RedirectToAction(MVC.Home.Index());
            }

            PopulateRestaurantSelectList(create);
            return View(create);
        }

        private void PopulateRestaurantSelectList(ViewModels.Review.Create model)
        {
            model.Restaurants = new SelectList(_restaurantRepository.GetAll(), "Id", "Name");
        }
    }
}