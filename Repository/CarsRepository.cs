using Cars_Den.Data;
using Cars_Den.Models;
using Cars_Den.Repository.IRepository;

namespace Cars_Den.Repository
{
    public class CarsRepository : Repository<Cars>, ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Additional method to get all cars
        public IQueryable<Cars> GetAllCars()
        {
            return _context.Cars;
        }
        public void Update(Cars obj)
        {
            _context.Cars.Update(obj);
        }
    }
}
