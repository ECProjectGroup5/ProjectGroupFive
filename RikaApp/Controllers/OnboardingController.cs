using Microsoft.AspNetCore.Mvc;

namespace RikaApp.Controllers
{
    public class OnboardingController : Controller
    {
        [Route("/onboarding")]
        public IActionResult OnBoarding()
        {
            return View();
        }
    }
}
