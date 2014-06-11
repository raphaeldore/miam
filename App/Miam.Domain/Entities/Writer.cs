using System.Collections.Generic;

namespace Miam.Domain.Entities
{
    public class Writer : User
    {
        //Navigation properties
        public virtual ICollection<Review> Reviews { get; set; }

        public Writer()
        {
            Reviews = new List<Review>();
        }
    }
}


