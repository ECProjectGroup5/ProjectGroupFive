using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class SplashScreenController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
