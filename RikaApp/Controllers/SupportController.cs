using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers;


public class SupportController : Controller
{
    [Route("/supporttelephone")]
    public IActionResult SupportTelephone()
    {
        return View();
    }
}
