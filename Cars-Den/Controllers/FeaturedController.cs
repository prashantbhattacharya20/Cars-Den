using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Den.Controllers
{
    public class FeaturedController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeaturedController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Featured()
        {
            List<Cars> obj = _unitOfWork.CarsRepository.GetAllCars().ToList();
            return View(obj);
        }
    }
}
