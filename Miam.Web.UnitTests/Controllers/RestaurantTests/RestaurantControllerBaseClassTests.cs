using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{

    public class RestaurantControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<Restaurant> _restaurantRepository;
        protected IEntityRepository<Review> _reviewRepository;
        protected RestaurantController _restaurantController;
       

        [TestInitialize]
        public void AdminControllerTestInit()
        {
            _restaurantRepository = Substitute.For<IEntityRepository<Restaurant>>();
            _reviewRepository = Substitute.For<IEntityRepository<Review>>();
            _restaurantController = new RestaurantController(_restaurantRepository);
        }
    }
}