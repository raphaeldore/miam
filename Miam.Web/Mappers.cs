using System.Collections.Generic;
using System.Linq;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;

namespace Miam.Web
{
    public static class Mappers
    {
        // Restaurant
        public static Restaurant createRestaurantFrom(RestaurantCreateViewModel restaurantViewModel)
        {
            return new Restaurant
            {
                Id = restaurantViewModel.RestaurantId,
                City = restaurantViewModel.City,
                Name = restaurantViewModel.Name,
                Country = restaurantViewModel.Country,
                RestaurantContactDetail = restaurantViewModel.RestaurantContactDetail,
            };
        }

        public static RestaurantDeleteViewModel createRestaurantDeleteViewModelFrom(Restaurant restaurant)
        {
            return new RestaurantDeleteViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                City = restaurant.City,
                Country = restaurant.Country
            };
        }

        public static RestaurantEditViewModel createRestaurantEditViewModelFrom(Restaurant restaurant)
        {
            return new RestaurantEditViewModel
            {
                Id = restaurant.Id,
                City = restaurant.City,
                Country = restaurant.Country,
                Name = restaurant.Name,
                RestaurantContactDetailViewModel = Mappers.createRestaurantContactDetailViewModelFrom(restaurant.RestaurantContactDetail),
                ReviewsViewModel = Mappers.createReviewViewModelFrom(restaurant.Reviews)
            }; 
        }

        private static List<ReviewIndexViewModel> createReviewViewModelFrom(ICollection<Review> reviews)
        {
            return reviews
                .Select(x => new ReviewIndexViewModel
                {
                    Body = x.Body,
                    Rating = x.Rating,
                    WriterName = x.Writer.Name
                }).ToList();
        }

        private static ContactDetailViewModel createRestaurantContactDetailViewModelFrom(RestaurantContactDetail restaurantContactDetail)
        {
            return new ContactDetailViewModel
            {
                Facebook = restaurantContactDetail.Facebook,
                FaxPhone = restaurantContactDetail.FaxPhone,
                OfficePhone = restaurantContactDetail.OfficePhone,
                TwitterAlias = restaurantContactDetail.TwitterAlias,
                WebPage = restaurantContactDetail.WebPage
            };

        }

        public static IEnumerable<HomeIndexViewModel> createHomeIndexViewModelFrom(List<Restaurant> restaurants)
        {
            return restaurants
                .Select(x => new HomeIndexViewModel
                {
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country,
                    RatingReviewsAverage = x.CalculateReviewsRatingAverage()
                }).ToList();
        }

        public static RestaurantCreateViewModel createRestaurantCreateViewModelFrom(Restaurant restaurant)
        {
            return new RestaurantCreateViewModel
            {
                RestaurantId = restaurant.Id,
                City = restaurant.City,
                Country = restaurant.Country,
                Name = restaurant.Name,
                RestaurantContactDetail = restaurant.RestaurantContactDetail

            };
        }




        public static IEnumerable<RestaurantIndexViewModel> createRestaurantIndexViewModelFrom(List<Restaurant> restaurants)
        {
            var homeIndexViewModel = restaurants
               .Select(x => new RestaurantIndexViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   City = x.City,
                   Country = x.Country,
                   RatingReviewsAverage = x.CalculateReviewsRatingAverage(),
                   CountOfReviews = x.Reviews.Count,
               }).ToList();

            return homeIndexViewModel;
        }


        //Review
        public static Review createReviewFrom(ReviewCreateViewModel reviewCreateViewModel)
        {
            var review = new Review
            {
                Body = reviewCreateViewModel.Body,
                Rating = reviewCreateViewModel.Rating,
                RestaurantId = reviewCreateViewModel.RestaurantId,
            };
            return review;
        }

        public static ReviewCreateViewModel createReviewCreateViewModelFrom(Review review)
        {
            return new ReviewCreateViewModel
            {
                RestaurantId = review.RestaurantId,
                Body = review.Body,
                Rating = review.Rating
            };
        }

        public static void updateRestaurantFromViewModel(RestaurantEditViewModel restaurantEditViewModel, Restaurant restaurant)
        {
            restaurant.City = restaurantEditViewModel.City;
            restaurant.Country = restaurantEditViewModel.Country;
            restaurant.Name = restaurantEditViewModel.Name;
            Mappers.updateRestaurantContactDetailFromViewModel(restaurant.RestaurantContactDetail, restaurantEditViewModel.RestaurantContactDetailViewModel);
        }

        private static void updateRestaurantContactDetailFromViewModel(RestaurantContactDetail restaurantContactDetail, ContactDetailViewModel restaurantContactDetailViewModel)
        {
            restaurantContactDetail.Facebook = restaurantContactDetailViewModel.Facebook;
            restaurantContactDetail.FaxPhone = restaurantContactDetailViewModel.FaxPhone;
            restaurantContactDetail.OfficePhone = restaurantContactDetailViewModel.OfficePhone;
            restaurantContactDetail.TwitterAlias = restaurantContactDetailViewModel.TwitterAlias;
            restaurantContactDetail.WebPage = restaurantContactDetailViewModel.WebPage;
        }
    }
}