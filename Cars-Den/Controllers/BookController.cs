using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class BookController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Book()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                TempData["Error"] = "Please Login First";
                return RedirectToAction("Login", "Login");
            }

            ViewBag.Cars = _unitOfWork.CarsRepository.GetAllCars().ToList();

            return View(new Bookings
            {
                // Initialize StartDate and EndDate with the current date
                StartDate = DateOnly.FromDateTime(DateTime.Today),
                EndDate = DateOnly.FromDateTime(DateTime.Today)
            });
        }

        [HttpGet]
        public JsonResult GetCarDetails(int carId)
        {
            var car = _unitOfWork.CarsRepository.GetAllCars()
                .Where(c => c.CarID == carId)
                .FirstOrDefault();
            return Json(car);
        }

        [HttpGet]
        public JsonResult GetAllCars()
        {
            var cars = _unitOfWork.CarsRepository.GetAllCars().ToList();
            return Json(cars);
        }


        [HttpPost]
        public IActionResult BookARide(Bookings booking)
        {
            try
            {

                // Retrieve the username from the session
                var username = HttpContext.Session.GetString("username");

                // Find the user in the database
                var user = _unitOfWork.UsersRepository.GetAllUsers()
                    .SingleOrDefault(u => u.Username == username);

                if (user != null)
                {
                    // Set the UserID on the booking
                    booking.UserID = user.UserID;

                    // Add the booking to the database
                    _unitOfWork.BookingsRepository.Update(booking);

                    _unitOfWork.Save();

                    // Redirect to a success page
                    return RedirectToAction("Index", "Home");
                }

                // Return an unauthorized error if the user is not logged in
                return Unauthorized("Please log in to book a ride.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
