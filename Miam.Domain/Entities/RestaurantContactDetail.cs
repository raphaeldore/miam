using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class RestaurantContactDetail       
    {
        public int RestaurantId { get; set; }  

        public string FaxPhone { get; set; }
        public string OfficePhone { get; set; }
        public string TwitterAlias { get; set; }
        public string Facebook { get; set; }
        public string WebPage { get; set; }

        //Navigation properties
        public virtual Restaurant Restaurant { get; set; }

    }
}
