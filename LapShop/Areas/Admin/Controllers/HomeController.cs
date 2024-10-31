using LapShop.Models;
using Microsoft.AspNetCore.Mvc;


namespace LapShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
          
            return View();
        }
     
    }
}
