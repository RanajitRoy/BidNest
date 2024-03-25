namespace items.Models
{
    public class Bid
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = "";
        public int Amount { get; set; }
    }
}
