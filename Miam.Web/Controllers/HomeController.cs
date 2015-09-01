using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;

namespace Miam.Web.Controllers
{

    public partial class HomeController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;


        public HomeController(IEntityRepository<Restaurant> restaurantRepository)
        {
            if (restaurantRepository == null) throw new NullReferenceException();

            _restaurantRepository = restaurantRepository;
        }

        public virtual ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetAll().ToList();

            var homeIndexViewModels = Mapper.Map<IEnumerable<HomeIndexViewModel>>(restaurants);

            return View(homeIndexViewModels);
        }
        
    }
}
