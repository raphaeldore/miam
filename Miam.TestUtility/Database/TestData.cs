using System.Collections.Generic;
using Miam.Domain.Application;
using Miam.Domain.Entities;

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
                             // sha256
                             Password = "AF7C880C6178C7DA849C55217816BAF4CDF37D8F6FD5C32E693AB272C7196EF9",
                             Name = "Irma Larose",
                             Email = "irma@Larose.fr",
                         };
                
                return writer;
            }
        }
        public static string Writer1PlainTextPwd = "irma";

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
                    // sha256
                    Password = "2EC50E8DCC57D282DFDC5B901F550A5E79D8E65535A65FB40EA358C2B7FB97FD",
                    Name = "Lucien Lafleur",
                    Email = "lucien@lafleur.com",

                };

                return writer;
            }
        }
        public static string Writer2PlainTextPwd = "lucien";
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

        #region Admin (writer with roles admin + writer)
        static public ApplicationUser ApplicationUserAdmin
        {
            get
            {
                var user = new Writer()

                {
                    Roles = new List<UserRole>()
                             {
                                 new UserRole() {RoleName = RoleName.Writer},
                                 new UserRole() {RoleName = RoleName.Admin}
                             },
                    Password = "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918",
                    Name = "Super AdminLafleur",
                    Email = "admin@admin.com",
                };

                return user;
            }
        }

        public static string ApplicationUserAdminPlainTextPwd = "admin";
        #endregion

       public static string WordFileName
       {
           //Le fichier se trouve dans la dossier TestFiles du projet Miam.Web.AcceptanceTests
           get { return "exemple.docx"; }
       }
        
    }
}