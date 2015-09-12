using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Review;

namespace Miam.Web.Controllers
{
    public partial class ReviewController : Controller
    {
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<Restaurant> _restaurantRepository;
        private readonly IEntityRepository<Writer> _writerRepository;

        public ReviewController(IEntityRepository<Restaurant> restaurantRepository,
                                IEntityRepository<Writer> writerRepository,
                                IHttpContextService httpContextService)
        {
            if (restaurantRepository == null) throw new NullReferenceException();
            if (writerRepository == null) throw new NullReferenceException();
            if (httpContextService == null) throw new NullReferenceException();

            _restaurantRepository = restaurantRepository;
            _writerRepository = writerRepository;
            _httpContextService = httpContextService;
        }

        [Authorize(Roles = Role.Writer)]
        public virtual ActionResult Create()
        {
            var model = new ReviewCreateViewModel();
            PopulateRestaurantSelectList(model);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Role.Writer)]
        public virtual ActionResult Create(ReviewCreateViewModel reviewCreateViewModel)
        {

            if (ModelState.IsValid)
            {
                var writerId = _httpContextService.GetUserId();
                var writer = _writerRepository.GetById(writerId);

                //Todo: faire la map
                var review = new Review()
                {
                    WriterId = writer.Id,
                    RestaurantId = reviewCreateViewModel.RestaurantId,
                    Body = reviewCreateViewModel.Body,
                    Rating = reviewCreateViewModel.Rating
                };

                writer.Reviews.Add(review);
                _writerRepository.Update(writer);

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