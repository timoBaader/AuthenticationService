using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
