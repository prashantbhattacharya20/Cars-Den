using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Book()
        {
            return View();
        }
    }
}
