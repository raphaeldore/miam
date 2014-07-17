using System.Collections.Generic;
using Miam.Domain.Entities;
using Miam.Domain.RoleName;

namespace Miam.TestUtility.Database
{
    public class TestData
    {
        #region Resto1 Le chameau pouilleux

        static public Restaurant Restaurant1
        {
            get
            {
                var restaurant = new Restaurant()
                {
                    Name = "Le chameau pouilleux",
                    City = "Lyon",
                    Country = "France"
                };

                return restaurant;
            }
        }
        public static RestaurantContactDetail RestaurantContactDetail1
        {
            get
            {
                var restaurantContactDetail = new RestaurantContactDetail()
                {
                    WebPage = "www.chameaupouilleux.ca"
                };

                return restaurantContactDetail;
            }
        }
        #endregion

        #region Resto 2 - Le cochon chevelu
        
        static public Restaurant Restaurant2
        {
            get
            {
                var restaurant = new Restaurant()
                {
                    Name = "Le cochon chevelu",
                    City = "Montréal",
                    Country = "Canada"
                };

                return restaurant;
            }
        }

        public static RestaurantContactDetail RestaurantContactDetail2
        {
            get
            {
                var restaurantContactDetail = new RestaurantContactDetail()
                {
                    WebPage = "www.lecochonchevelu.com"
                };

                return restaurantContactDetail;
            }
        }
        #endregion

        #region Resto 3 - Bambine et Bounette
        public static Restaurant Restaurant3
        {
            get
            {
                var newRestaurant = new Restaurant()
                {
                    Name = "Bambine et Bounette",
                    City = "Trois-Rivière",
                    Country = "Canada",
                    RestaurantContactDetail = new RestaurantContactDetail()
                    {
                        Facebook = "BamBounette",
                        OfficePhone = "123-888-4567",
                        FaxPhone = "123-888-4569",
                        TwitterAlias = "BamBou",
                        WebPage = "www.bambinebounette.com"
                    }
                };
                return newRestaurant;
            }
        }
        #endregion

        #region Writers
        
        static public Writer Writer1
        {
            get
            {

                var writer = new Writer()

                         {
                             Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Writer}
                             },
                             Password= "irma",
                             Name = "Irma Larose",
                             Email = "irma@Larose.fr",
                         };
                
                return writer;
            }
        }

        static public Writer Writer2
        {
            get
            {
                var writer = new Writer()

                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Writer}
                             },
                    Password = "lucien", 
                    Name = "Lucien Lafleur",
                    Email = "lucien@lafleur.com",

                };

                return writer;
            }
        }
        #endregion

        #region tags
        public static Tag Tag1
        {
            get
            {

                var tag = new Tag()
                {
                    Title = "Chinois"
                };

                return tag;
            }
        }

        public static Tag Tag2
        {
            get
            {

                var tag = new Tag()
                {
                    Title = "Urbain"
                };

                return tag;
            }
        }
        #endregion

        #region reviews
        public static Review Review1
        {
            get
            {

                var review = new Review()
                {
                    Body = "Service génial",
                    Rating = 4
                };
                return review;
            }
        }

        public static Review Review2
        {
            get
            {

                var review = new Review()
                             {
                                 Body = "Trop familier",
                                 Rating = 2
                             };
                return review;
            }
        }

        public static Review Review3
        {
            get
            {

                var review = new Review()
                {
                    Body = "Super la poutine thai !",
                    Rating = 5
                };
                return review;
            }
        }
        #endregion

        #region user - admin
        static public User UserAdmin
        {
            get
            {
                var user = new User()

                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Writer},
                                 new UserRole() {RoleName = RoleName.Admin}
                             },
                    Password = "admin",
                    Name = "Super AdminLafleur",
                    Email = "admin@admin.com",
                };

                return user;
            }
        }
        #endregion
    }
}