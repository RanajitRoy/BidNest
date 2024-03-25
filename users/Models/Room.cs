using System.ComponentModel.DataAnnotations.Schema;

namespace users.Models
{
    [Table("Room")]
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
    }
}
