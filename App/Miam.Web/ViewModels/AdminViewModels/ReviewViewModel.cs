using System.Web.Mvc;

namespace Miam.Web.ViewModels.AdminViewModels
{
    public class ReviewViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public string WriterName { get; set; }
    }
}