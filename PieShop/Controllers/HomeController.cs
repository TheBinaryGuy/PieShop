﻿using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;
using System.Linq;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPieRepository pieRepository, IFeedbackRepository feedbackRepository)
        {
            PieRepository = pieRepository;
            FeedbackRepository = feedbackRepository;
        }

        private IPieRepository PieRepository { get; }
        private IFeedbackRepository FeedbackRepository { get; }

        public IActionResult Index()
        {
            var pies = PieRepository.GetAllPies().OrderBy(p => p.Name);
            var model = new HomeViewModel
            {
                Title = "Pie Shop",
                Pies = pies.ToList()
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
