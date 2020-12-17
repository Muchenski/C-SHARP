using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Models.ViewModels;

namespace WebProject.Controllers
{
    // Controlador da pasta HOME
    public class HomeController:Controller
    {
        // O nome do método que controla uma determinada página deve ter o mesmo nome
        // da respectiva página controlada.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            // Resposta da requisição da ação "About".

            // O Asp Net core utiliza o padrão Natural Templates:
            // A URL chama o método do controlador, e o método do controlador
            // encaminha a requisição para a página definida no retorno.

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
