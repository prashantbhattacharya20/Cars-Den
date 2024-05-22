using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class AdminController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Admin()
        {
            List<Cars> obj = _unitOfWork.CarsRepository.GetAll().ToList();
            return View(obj);
        }

        // Display the form for adding a new car
        public IActionResult AddNewCar()
        {
            return View();
        }

        // Action to handle the post request when adding a new car
        [HttpPost, ActionName("AddNewCar")]
        public IActionResult AddNewCar(Cars obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CarsRepository.Add(obj);
                    _unitOfWork.Save();
                    return RedirectToAction("Admin", "Admin");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return View();
        }

        // Action to display the form for editing a car
        public IActionResult EditCar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            try
            {
                Cars carData = _unitOfWork.CarsRepository.Get(Id.Value);
                if (carData != null) { return View(carData); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return NotFound();
        }

        // Action to handle the post request when editing a car
        [HttpPost, ActionName("EditCar")]
        public IActionResult EditCar(Cars obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CarsRepository.Update(obj);
                    _unitOfWork.Save();
                    return RedirectToAction("Admin", "Admin");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return View(obj);
        }

        // Action to display the form for deleting a car
        public IActionResult DeleteCar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            try
            {
                Cars carData = _unitOfWork.CarsRepository.Get(Id.Value);
                if (carData != null)
                {
                    return View(carData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return NotFound();
        }

        // Action to handle the post request when deleting a car
        [HttpPost, ActionName("DeleteCar")]
        public IActionResult DeleteCar(Cars obj)
        {
            try
            {
                Cars carData = _unitOfWork.CarsRepository.Get(obj.CarID);
                if (carData != null)
                {
                    _unitOfWork.CarsRepository.Remove(carData);
                    _unitOfWork.Save();
                    return RedirectToAction("Admin", "Admin");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return NotFound();
        }
    }
}
