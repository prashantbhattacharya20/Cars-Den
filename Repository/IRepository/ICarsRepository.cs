using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using System.Linq;

namespace Cars_Den.Repository.IRepository
{
    public interface ICarsRepository : IRepository<Cars>
    {
        // Custom method to get all cars
        IQueryable<Cars> GetAllCars();

        void Update(Cars obj);
    }
}
