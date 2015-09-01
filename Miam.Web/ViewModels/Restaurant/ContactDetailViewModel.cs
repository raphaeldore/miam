using System.ComponentModel;

namespace Miam.Web.ViewModels.Restaurant
{
    public class ContactDetailViewModel
    {
        [DisplayName("Fax")]
        public string FaxPhone { get; set; }

        [DisplayName("Téléphone")]
        public string OfficePhone { get; set; }

        [DisplayName("Twitter")]
        public string TwitterAlias { get; set; }

        [DisplayName("Facebook")]
        public string Facebook { get; set; }

        [DisplayName("Site web")]
        public string WebPage { get; set; }

    }
}