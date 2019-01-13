using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class FeedbackController : Controller
    {
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            FeedbackRepository = feedbackRepository;
        }
        
        private IFeedbackRepository FeedbackRepository { get; }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Feedback();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }
            FeedbackRepository.AddFeedback(feedback);
            TempData["ContactMe"] = feedback.ContactMe;
            return RedirectToAction("FeedbackComplete");
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
