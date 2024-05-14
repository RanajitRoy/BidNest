using System.ComponentModel.DataAnnotations.Schema;

namespace users.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Salt { get; set; }
        public required string HashedPassword { get; set; }
    }
}
