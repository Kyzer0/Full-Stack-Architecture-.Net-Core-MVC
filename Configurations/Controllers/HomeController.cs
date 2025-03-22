using Microsoft.AspNetCore.Mvc;

namespace Configurations.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
