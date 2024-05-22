using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using System.Linq;

namespace Cars_Den.Repository.IRepository
{
    public interface IBookingsRepository : IRepository<Bookings>
    {
        // Custom method to get all cars
        IQueryable<Bookings> GetAllBookings();

        void Update(Bookings obj);
    }
}
