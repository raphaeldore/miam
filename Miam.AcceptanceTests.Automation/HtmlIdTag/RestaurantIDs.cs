using Miam.Web.ViewModels.Restaurant;

namespace Miam.AcceptanceTests.Automation.HtmlIdTag
{
    public class RestaurantIDs
    {
        public static string Country
        {
            get {return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.Country);}
        }

        public static string City
        {
            get { return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.City);}
        }

        public static string Name
        {
            get { return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.Name); }
        }
        public static string ContactDetail
        {
            get
            {
                return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.ContactDetailViewModel);
            }
        }
        public static string FaxPhone
        {
            get
            {
                return RestaurantIDs.ContactDetail + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.FaxPhone);
            }
        }
        public static string WebPage
        {
            get
            {
                return RestaurantIDs.ContactDetail + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.WebPage);
            }
        }

        public static string FaceBook
        {
            get
            {
                return RestaurantIDs.ContactDetail + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.Facebook);
            }
        }

        public static string Twitter
        {
            get
            {
                return RestaurantIDs.ContactDetail + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.TwitterAlias);
            }
        }

        public static string OfficePhone
        {
            get
            {
                return RestaurantIDs.ContactDetail + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.OfficePhone);
            }
        }
    }
}
