using System.ComponentModel.DataAnnotations.Schema;

namespace items.Models
{
    public class Bid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required int Amount { get; set; }
        public required User User { get; set; }
    }
}
