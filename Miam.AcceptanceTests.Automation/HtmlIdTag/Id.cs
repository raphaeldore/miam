using Miam.Web.ViewModels.Account;
using Miam.Web.ViewModels.Restaurant;

namespace Miam.AcceptanceTests.Automation.HtmlIdTag
{
    public static class Id
    {
        public static class Restaurant 
        {
            public static string Country
            {
                get { return PropertiesTool<RestaurantCreateViewModel>.GetPropertyName(x => x.Country); }
            }

            public static string City
            {
                get { return PropertiesTool<RestaurantCreateViewModel>.GetPropertyName(x => x.City); }
            }

            public static string Name
            {
                get { return PropertiesTool<RestaurantCreateViewModel>.GetPropertyName(x => x.Name); }
            }
            public static string ContactDetail
            {
                get
                {
                    return PropertiesTool<RestaurantCreateViewModel>.GetPropertyName(x => x.ContactDetailViewModel);
                }
            }
            public static string FaxPhone
            {
                get
                {
                    return ContactDetail + "_" +
                           PropertiesTool<ContactDetailViewModel>.GetPropertyName(x => x.FaxPhone);
                }
            }
            public static string WebPage
            {
                get
                {
                    return ContactDetail + "_" +
                           PropertiesTool<ContactDetailViewModel>.GetPropertyName(x => x.WebPage);
                }
            }

            public static string FaceBook
            {
                get
                {
                    return ContactDetail + "_" +
                           PropertiesTool<ContactDetailViewModel>.GetPropertyName(x => x.Facebook);
                }
            }

            public static string Twitter
            {
                get
                {
                    return ContactDetail + "_" +
                           PropertiesTool<ContactDetailViewModel>.GetPropertyName(x => x.TwitterAlias);
                }
            }

            public static string OfficePhone
            {
                get
                {
                    return ContactDetail + "_" +
                           PropertiesTool<ContactDetailViewModel>.GetPropertyName(x => x.OfficePhone);
                }
            }
            
        }

        public static class Account
        {
            public static string Email
            {
                get { return PropertiesTool<LoginViewModel>.GetPropertyName(x => x.Email); }
            }
            public static string Password
            {
                get { return PropertiesTool<LoginViewModel>.GetPropertyName(x => x.Password); }
            }
        }
        
    }
}
