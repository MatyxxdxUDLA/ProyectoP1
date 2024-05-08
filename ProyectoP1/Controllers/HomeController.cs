using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoP1.Models;
using ProyectoP1.Permisos;
using System.Diagnostics;

namespace ProyectoP1.Controllers
{
    [ValidarSesion]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult CerrarSesion()
		{
			HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(null));
			return RedirectToAction("Login", "Acceso");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
