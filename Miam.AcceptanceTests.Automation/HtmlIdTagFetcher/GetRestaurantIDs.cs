using Miam.Web.ViewModels.Restaurant;

namespace Miam.AcceptanceTests.Automation.PageObjects.RestaurantPages
{
    public class GetRestaurantIDs
    {
        public static string CountryId
        {
            get {return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.Country);}
        }

        public static string CityId
        {
            get { return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.City);}
        }

        public static string NameId
        {
            get { return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.Name); }
        }
        public static string GetContactDetailName
        {
            get
            {
                return ObjectsTool<RestaurantCreateViewModel>.GetPropertyName(x => x.ContactDetailViewModel);
            }
        }
        public static string FaxPhoneId
        {
            get
            {
                return GetRestaurantIDs.GetContactDetailName + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.FaxPhone);
            }
        }
        public static string WebPageId
        {
            get
            {
                return GetRestaurantIDs.GetContactDetailName + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.WebPage);
            }
        }

        public static string FaceBookId
        {
            get
            {
                return GetRestaurantIDs.GetContactDetailName + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.Facebook);
            }
        }

        public static string TwitterId
        {
            get
            {
                return GetRestaurantIDs.GetContactDetailName + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.TwitterAlias);
            }
        }

        public static string OfficePhoneId
        {
            get
            {
                return GetRestaurantIDs.GetContactDetailName + "_" +
                       ObjectsTool<ContactDetailViewModel>.GetPropertyName(x => x.OfficePhone);
            }
        }
    }
}
