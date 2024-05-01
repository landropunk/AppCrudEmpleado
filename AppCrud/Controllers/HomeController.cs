using AppCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppCrud.Controllers
{
    /// <summary>
    /// Controlador para la p�gina de inicio.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor para HomeController.
        /// </summary>
        /// <param name="logger">El logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Devuelve la vista de la p�gina de inicio.
        /// </summary>
        /// <returns>La vista de la p�gina de inicio.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Devuelve la vista de la p�gina de privacidad.
        /// </summary>
        /// <returns>La vista de la p�gina de privacidad.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Devuelve la vista de la p�gina de error.
        /// </summary>
        /// <returns>La vista de la p�gina de error.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
