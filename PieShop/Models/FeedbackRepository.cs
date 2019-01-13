using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private AppDbContext _appDbContext { get; }

        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Feedback AddFeedback(Feedback feedback)
        {
            var entityEntry = _appDbContext.Feedbacks.Add(feedback).Entity;
            _appDbContext.SaveChanges();

            return entityEntry;
        }
    }
}
