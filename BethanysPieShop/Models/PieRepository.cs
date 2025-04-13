using BethanysPieShop.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _context;
        public PieRepository(BethanysPieShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pie> AllPies => _context.Pies.Include(c => c.Category);
        
        public IEnumerable<Pie> PiesOfTheWeek => _context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
        
        public Pie GetPieById(int pieId) => _context.Pies.FirstOrDefault(p => p.PieId == pieId);
       
        public IEnumerable<Pie> GetPiesByCategory(string category) =>
            _context.Pies.Include(c => c.Category).Where(p => p.Category.CategoryName == category);
        
        public void SaveChanges() => _context.SaveChanges();

        public IEnumerable<Pie> SearchPies(string searchQuery) => _context.Pies.Where(p => p.Name.Contains(searchQuery));

    }
}
