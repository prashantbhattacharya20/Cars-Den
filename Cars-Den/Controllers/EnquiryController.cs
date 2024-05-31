using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class EnquiryController : Controller
    {
        public IActionResult Enquiry()
        {
            return View();
        }
    }
}
