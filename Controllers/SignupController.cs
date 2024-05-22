using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }
    }
}
