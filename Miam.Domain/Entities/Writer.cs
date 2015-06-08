using System.Collections.Generic;

namespace Miam.Domain.Entities
{
    public class Writer : ApplicationUser
    {
        //Navigation properties
        public virtual ICollection<Review> Reviews { get; set; }

        public Writer()
        {
            Reviews = new List<Review>();
        }
    }
}


