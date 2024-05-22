using Cars_Den.Data;
using Cars_Den.Models;
using Cars_Den.Repository.IRepository;

namespace Cars_Den.Repository
{
    //This class is used for providing a single interface for the different repositories.
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICarsRepository Cars { get; set; }
        public IUsersRepository Users { get; set; }
        public IBookingsRepository Bookings { get; set; }

        public ICarsRepository CarsRepository => throw new NotImplementedException();

        public IUsersRepository UsersRepository => throw new NotImplementedException();

        public IBookingsRepository BookingsRepository => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Cars = new CarsRepository(_context);
            Users = new UsersRepository(_context);
            Bookings = new BookingsRepository(_context);
        }

        //This method is used for saving changes in the database.
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
