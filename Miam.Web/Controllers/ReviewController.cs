using System;
using System.Web.Mvc;
using AutoMapper;
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
        private readonly IEntityRepository<Review> _reviewRepository;
        private readonly IEntityRepository<Restaurant> _restaurantRepository;
        private readonly IEntityRepository<Writer> _writerRepository;

        public ReviewController(IEntityRepository<Review> reviewRepository,
                                IEntityRepository<Restaurant> restaurantRepository,
                                IEntityRepository<Writer> writerRepository,
                                IHttpContextService httpContextService)
        {

            if (reviewRepository == null) throw new NullReferenceException();
            if (restaurantRepository == null) throw new NullReferenceException();
            if (writerRepository == null) throw new NullReferenceException();
            if (httpContextService == null) throw new NullReferenceException();

            _reviewRepository = reviewRepository;
            _restaurantRepository = restaurantRepository;
            _writerRepository = writerRepository;
            _httpContextService = httpContextService;
        }

        [Authorize(Roles = RoleName.Writer)]
        public virtual ActionResult Create()
        {
            var model = new Create();
            PopulateRestaurantSelectList(model);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Writer)]
        public virtual ActionResult Create(Create createViewModel)
        {
            var uw = new EfUnitOfWork();

            if (ModelState.IsValid)
            {
                var WriterId = _httpContextService.GetUserId();
                var writer = uw.WriterRepository.GetById(WriterId);
                var restaurant = uw.RestaurantRepository.GetById(createViewModel.RestaurantId);
                
                //var review = Mapper.Map<Review>(createViewModel);

                var review = new Review()
                {
                    Writer = writer,
                    Restaurant = restaurant,
                    Body = createViewModel.Body,
                    Rating = createViewModel.Rating
                };
                //review.Restaurant = restaurant;
                writer.Reviews.Add(review);

                uw.WriterRepository.Update(writer);

                return RedirectToAction(MVC.Home.Index());
            }

            PopulateRestaurantSelectList(createViewModel);
            return View(createViewModel);
        }

        private void PopulateRestaurantSelectList(Create model)
        {
            var uw = new EfUnitOfWork();
            model.Restaurants = new SelectList(uw.RestaurantRepository.GetAll(), "Id", "Name");
        }
    }
}