using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using System.Diagnostics;

namespace ProyectoFinal.Controllers// la migracion crea la tabla en el sql
{//add-Migration //Update-Database -verbose
    public class HomeController : Controller
    {//controlador por omision
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()//vista index
        {
            return View();
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