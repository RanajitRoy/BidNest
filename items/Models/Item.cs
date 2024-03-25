namespace items.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
