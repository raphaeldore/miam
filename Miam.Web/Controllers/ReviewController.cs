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

            if (ModelState.IsValid)
            {
                var WriterId = _httpContextService.GetUserId();
                var writer = _writerRepository.GetById(WriterId);
                var restaurant = _restaurantRepository.GetById(createViewModel.RestaurantId);

                var review = new Review()
                {
                    Writer = writer,
                    Restaurant = restaurant,
                    Body = createViewModel.Body,
                    Rating = createViewModel.Rating
                };

                //writer.Reviews.Add(review);
                //_writerRepository.Update(writer);
                //ou
                restaurant.Reviews.Add(review);
                _restaurantRepository.Update(restaurant);

                return RedirectToAction(MVC.Home.Index());
            }

            PopulateRestaurantSelectList(createViewModel);
            return View(createViewModel);
        }

        private void PopulateRestaurantSelectList(Create model)
        {
            model.Restaurants = new SelectList(_restaurantRepository.GetAll(), "Id", "Name");
        }
    }
}