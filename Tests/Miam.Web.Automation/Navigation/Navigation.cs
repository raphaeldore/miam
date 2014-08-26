namespace Miam.Web.Automation
{
    public class Navigation
    {
        public class Admin
        {
            public class EditRestaurant
            {
                public static void Select()
                {
                    MenuSelector.Select("admin-menu", "manage-restaurant-menu-item");
                }
            }
            public class CreateRestaurant
            {
                public static void Select()
                {
                    MenuSelector.Select("admin-menu", "add-restaurant-menu-item");
                }
            }
        }

        public class Writer
        {
            public class CreateReview
            {
                public static void Select()
                {
                    MenuSelector.Select("writer-menu", "add-review-menu-item");
                }
            }
        }

        public class AllUsers
        {
            public class Home
            {

                public static void Select()
                {
                    MenuSelector.Select("home-link");
                }
            }


            public class Login
            {
                public static void Select()
                {
                    MenuSelector.Select("login-link");
                }
            }
            public class Logout
            {
                public static void Select()
                {
                    MenuSelector.Select("logout-link");
                }


            }
        }
    }
}








