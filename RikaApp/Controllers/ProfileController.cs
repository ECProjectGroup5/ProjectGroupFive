using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
