using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;
using System.Linq;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
            PieRepository = pieRepository;
        }

        private ICategoryRepository CategoryRepository { get; }
        private IPieRepository PieRepository { get; }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Title = "Pie Shop",
                Pies = PieRepository.Pies.OrderBy(p => p.Name).ToList()
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var pie = PieRepository.GetPieById(id);
            if (pie == null) return NotFound();
            return View(pie);
        }
    }
}
