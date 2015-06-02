using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.Web.Automation.AcceptanceTestApi
{
    public class RestaurantAcceptanceTestApi
    {
        private IEntityRepository<Restaurant> _restaurantRepository;

        public RestaurantAcceptanceTestApi()
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>();
        }
        public void createRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

    }
}
