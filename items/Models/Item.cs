using System.ComponentModel.DataAnnotations.Schema;

namespace items.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
