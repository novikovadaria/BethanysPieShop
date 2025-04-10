using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.MyDbContext
{
    public class BethanysPieShopDbContext : DbContext
    {
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }
    }
}
