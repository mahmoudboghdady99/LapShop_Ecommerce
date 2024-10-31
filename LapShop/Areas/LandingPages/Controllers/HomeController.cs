using Microsoft.AspNetCore.Mvc;

namespace FirstApp2.Areas.LandingPages.Controllers
{
    [Area("LandingPages")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
