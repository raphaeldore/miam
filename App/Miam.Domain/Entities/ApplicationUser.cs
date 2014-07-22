using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class ApplicationUser : Entity
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        //Navigation properties
        public virtual ICollection<UserRole> Roles { get; set; }

        public ApplicationUser()
        {
            Roles = new List<UserRole>();
        }
  
    }
}