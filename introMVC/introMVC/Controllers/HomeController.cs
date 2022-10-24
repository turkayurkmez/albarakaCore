using introMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace introMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string test = "";
            var products = new List<Product>()
            {
                new Product{ Id=1, Name="A", Price=1, Description="Bilmemne"},
                new Product{ Id=2, Name="B", Price=1, Description="Bilmemne"},
                new Product{ Id=3, Name="C", Price=1, Description="Bilmemne"}
            };
            ViewBag.Name = "Türkay";
            ViewBag.Visit = DateTime.Now.ToShortTimeString();


            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}