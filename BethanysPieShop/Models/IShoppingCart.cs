namespace BethanysPieShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);
        List<ShoppingCardItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCardItem> ShoppingCartItems { get; set; }
    }
}
