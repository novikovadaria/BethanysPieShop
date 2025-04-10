using BethanysPieShop.MyDbContext;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _context;
        public CategoryRepository(BethanysPieShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => _context.Categories.OrderBy(c=>c.CategoryName);
        
        public Category GetCategoryById(int categoryId) => _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        
        public void SaveChanges() => _context.SaveChanges();
    }
}
