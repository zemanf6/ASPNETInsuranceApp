using System.Diagnostics;
using InsuranceApp.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
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
