using System.ComponentModel.DataAnnotations.Schema;

namespace users.Models
{
    [Table("users")]
    public class User
    {
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Salt { get; set; } = "";
        public string HashedPassword { get; set; } = "";
    }
}
