using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class MyCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
