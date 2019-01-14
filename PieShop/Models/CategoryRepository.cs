using System.Collections.Generic;

namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public IEnumerable<Category> Categories { get => _appDbContext.Categories; }

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
