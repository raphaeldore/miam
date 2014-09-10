using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Domain.RoleName;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;
using Create = Miam.Web.ViewModels.Restaurant.Create;
using Index = Miam.Web.ViewModels.Review.Index;

namespace Miam.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public partial class RestaurantController : Controller
    {
        private readonly IEntityRepository<Restaurant> _restaurantRepository;

        public RestaurantController(IEntityRepository<Restaurant> restaurantRepository)
        {
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
                var restaurantEditPageViewModel = Mapper.Map<Edit>(restaurant);
               
                return View(restaurantEditPageViewModel);
            }
            return HttpNotFound();
        }


        [HttpPost]
        public virtual ActionResult Edit(Edit edit)
        {
            var restaurant = _restaurantRepository.GetById(edit.Id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                edit.Reviews = Mapper.Map<List<Index>>(restaurant.Reviews);
                return View(edit);
            }

            Mapper.Map(edit, restaurant);

            _restaurantRepository.Update(restaurant);

            return RedirectToAction(Views.ViewNames.Index);
        }


        [HttpGet]
        public virtual ActionResult Delete(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);

            if (restaurant != null)
            {
                var restaurantViewModel = Mapper.Map<Delete>(restaurant);
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
        public virtual ActionResult Create(Create create)
        {
            if (ModelState.IsValid)
            {
                var restaurant = Mapper.Map<Restaurant>(create);
                _restaurantRepository.Add(restaurant);
                return RedirectToAction(Views.ViewNames.Index);
            }
            return View("");
        }
    }
}
