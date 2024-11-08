using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
