namespace Miam.Web.Automation
{
    public class Navigation
    {
        public class Admin
        {
            public class ManageRestaurant
            {
                public static void Select()
                {
                    MenuSelector.Select("admin-menu", "manage-restaurant-menu-item");
                }
            }
        }

        public class Writer
        {
            public class AddRestaurant
            {
                public static void Select()
                {
                    MenuSelector.Select("writer-menu", "add-restaurant-menu-item");
                }
            }
        }
    }
}