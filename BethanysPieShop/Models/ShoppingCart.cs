using BethanysPieShop.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly BethanysPieShopDbContext _context;

        public string? ShoppingCartId { get; set; }
        public List<ShoppingCardItem>? ShoppingCartItems { get; set; }
        public ShoppingCart(BethanysPieShopDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCard(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            BethanysPieShopDbContext context = service.GetService<BethanysPieShopDbContext>() ?? throw new ArgumentNullException(nameof(context));

            string cardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();

            session.SetString("CardId", cardId);

            return new ShoppingCart(context) { ShoppingCartId = cardId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCardItem = _context.ShoppingCardItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCardId == ShoppingCartId);
            if (shoppingCardItem == null)
            {
                shoppingCardItem = new ShoppingCardItem
                {
                    ShoppingCardId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };
                _context.ShoppingCardItems.Add(shoppingCardItem);
            }
            else
            {
                shoppingCardItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCardItem = _context.ShoppingCardItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCardId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCardItem != null)
            {
                if (shoppingCardItem.Amount > 1)
                {
                    shoppingCardItem.Amount--;
                    localAmount = shoppingCardItem.Amount;
                }
                else
                {
                    _context.ShoppingCardItems.Remove(shoppingCardItem);
                }
            }
            _context.SaveChanges();
            return localAmount;
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }

        public void ClearCart()
        {
            var shoppingCardItems = _context.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCartId);
            _context.ShoppingCardItems.RemoveRange(shoppingCardItems);
            _context.SaveChanges();
        }

        public List<ShoppingCardItem> GetShoppingCartItems()
        {
            var items = _context.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCartId)
                .Include(s => s.Pie).ToList();
            return items;
        }
    }
}
