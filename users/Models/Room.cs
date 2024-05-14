using System.ComponentModel.DataAnnotations.Schema;

namespace users.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required string Name { get; set; }
    }
}
