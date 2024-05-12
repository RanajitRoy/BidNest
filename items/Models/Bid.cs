namespace items.Models
{
    public class Bid
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Amount { get; set; }
    }
}
