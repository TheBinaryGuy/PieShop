using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public FeedbackController(UserManager<IdentityUser> userManager, IFeedbackRepository feedbackRepository)
        {
            _userManager = userManager;
            FeedbackRepository = feedbackRepository;
        }
        
        private IFeedbackRepository FeedbackRepository { get; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new Feedback { Name = user?.UserName, Email = user?.Email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
