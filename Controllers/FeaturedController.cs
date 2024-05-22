using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class FeaturedController : Controller
    {
        public IActionResult Featured()
        {
            return View();
        }
    }
}
