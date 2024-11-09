using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
