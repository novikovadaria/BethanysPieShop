using BethanysPieShop.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethanysPieShopDbContext _context;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BethanysPieShopDbContext context,IShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCardItem>? shoppingCardItems = _shoppingCart.GetShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            foreach (ShoppingCardItem? shoppingCardItem in shoppingCardItems)
            { 
                var orderDetail = new OrderDetail()
                {
                    PieId = shoppingCardItem.Pie.PieId,
                    Amount = shoppingCardItem.Amount,
                    Price = shoppingCardItem.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
