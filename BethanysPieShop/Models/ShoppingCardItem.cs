namespace BethanysPieShop.Models
{
    public class ShoppingCardItem
    {
        public int ShoppingCardItemId { get; set; }
        public Pie Pie { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCardId { get; set; }
    }
}
