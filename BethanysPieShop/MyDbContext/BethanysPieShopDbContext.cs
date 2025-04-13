using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.MyDbContext
{
    public class BethanysPieShopDbContext : IdentityDbContext
    {
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
