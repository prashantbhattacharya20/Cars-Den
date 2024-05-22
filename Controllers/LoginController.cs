using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
