using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class SignupController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SignupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost, ActionName("Signup")]

        public IActionResult Signup(Users obj)
        {
            try
            {
                // Check if the model state is valid
                if (ModelState.IsValid)
                {
                    // Add the user to the database
                    _unitOfWork.UsersRepository.Update(obj);
                    _unitOfWork.Save();

                    // Set a success message
                    TempData["success"] = "New User Created Successfully.";

                    // Redirect to the login page
                    return RedirectToAction("Login", "Login");
                }
                // If the model state is not valid, re-render the signup view
                return View();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
