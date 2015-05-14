using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class Tag : Entity
    {
        [StringLength(100)]
        public string Title { get; set; }
        public string TestMigration { get; set; }

        //Navigation properties
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
