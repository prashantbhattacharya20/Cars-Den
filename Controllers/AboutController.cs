using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
