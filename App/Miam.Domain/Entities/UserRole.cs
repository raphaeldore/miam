namespace Miam.Domain.Entities
{
    public class UserRole : Entity
    {

        public string RoleName { get; set; }

        // Foreign key
        public int UserId { get; set; }

        //Navigation properties
        public User Users { get; set; }

    }
}