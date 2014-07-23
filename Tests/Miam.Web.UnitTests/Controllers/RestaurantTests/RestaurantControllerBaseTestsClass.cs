using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{

    public class RestaurantControllerBaseTestsClass : ControllerBaseTestsClass
    {
        protected IEntityRepository<Restaurant> _restaurantRepository;
        protected IEntityRepository<Review> _reviewRepository;
        
        protected RestaurantController _adminController;
       

        [TestInitialize]
        public void AdminControllerTestInit()
        {
            _restaurantRepository = Substitute.For<IEntityRepository<Restaurant>>();
            _reviewRepository = Substitute.For<IEntityRepository<Review>>();

            _adminController = new RestaurantController(_restaurantRepository);
        }
    }
}