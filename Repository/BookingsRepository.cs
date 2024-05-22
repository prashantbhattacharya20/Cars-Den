using Cars_Den.Data;
using Cars_Den.Models;
using Cars_Den.Repository.IRepository;

namespace Cars_Den.Repository
{
    public class BookingsRepository : Repository<Bookings>, IBookingsRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Additional method to get all cars
        public IQueryable<Bookings> GetAllBookings()
        {
            return _context.Bookings;
        }
        public void Update(Bookings obj)
        {
            _context.Bookings.Update(obj);
        }
    }
}
