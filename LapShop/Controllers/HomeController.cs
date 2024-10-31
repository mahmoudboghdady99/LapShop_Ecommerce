using Microsoft.AspNetCore.Mvc;
using LapShop.Models;

namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            LapShopContext ctx = new LapShopContext();
            var categories = ctx.TbCategories.ToList();
            return View(categories);
        }
    }
}
