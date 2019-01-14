using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public IEnumerable<Pie> Pies { get => _appDbContext.Pies.Include(pie => pie.Category); }
        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
