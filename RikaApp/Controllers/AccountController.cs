using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers;


[Authorize]
public class AccountController : Controller
{
    public IActionResult Profile()
    {
        return View();
    }
}
