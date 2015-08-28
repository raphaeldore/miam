using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class UserRole : Entity
    {

        public string RoleName { get; set; }

        // Foreign key
        public int ApplicationUserId { get; set; }

        //Navigation properties
        [Required]
        public ApplicationUser ApplicationUsers { get; set; }

    }
}