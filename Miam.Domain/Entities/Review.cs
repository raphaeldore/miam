using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class Review : Entity
    {
        [Range(1, 5)]
        //[Required]
        public int Rating { get; set; }
        [StringLength(1024)]
        public string Body { get; set; }

        // Foreign key
        //public int RestaurantId { get; set; }
        //public int WriterId { get; set; }

        //Navigation properties
        [Required]
        public virtual Writer Writer { get; set; }
        [Required]
        public virtual Restaurant Restaurant { get; set; }
    }
}
