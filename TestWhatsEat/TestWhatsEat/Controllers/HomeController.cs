using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWhatsEat.Models;

namespace TestWhatsEat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<DishViewModel> dishes = new List<DishViewModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(dishes);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            DishViewModel dishVM = new DishViewModel();
            return View(dishVM);
        }

        public IActionResult CreateDish(DishViewModel dishViewModel)
        {
            dishes.Add(dishViewModel);
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}