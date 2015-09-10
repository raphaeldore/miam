using System.ComponentModel;
using Externalization;

namespace Miam.Web.ViewModels.Restaurant
{
    public class ContactDetailViewModel
    {

        [DisplayName(UiText.Restaurant.FAX)]
        public string FaxPhone { get; set; }

        [DisplayName(UiText.Restaurant.PHONE)]
        public string OfficePhone { get; set; }

        [DisplayName(UiText.Restaurant.TWITTER)]
        public string TwitterAlias { get; set; }

        [DisplayName(UiText.Restaurant.FACEBOOK)]
        public string Facebook { get; set; }

        [DisplayName(UiText.Restaurant.WEBSITE)]
        public string WebPage { get; set; }

    }
}