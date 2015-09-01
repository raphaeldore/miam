using System.Collections.Generic;

namespace Miam.Domain.Entities
{
    public class Writer : MiamUser
    {
        //Navigation properties
        public virtual ICollection<Review> Reviews { get; set; }

        public Writer()
        {
            Reviews = new List<Review>();
        }
    }
}


