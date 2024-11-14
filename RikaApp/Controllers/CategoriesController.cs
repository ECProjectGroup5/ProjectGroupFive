using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class CategoriesController : Controller
    {
        [Route("/categories")]

        public IActionResult Index()
        {
            return View();

        }
        [Route("/categories2")]
        public IActionResult Page2()
        {
            return View();
        }
        [Route("/categories3")]
        public IActionResult Page3()
        {
            return View();
        }
    }
}
