using Cars_Den.Data;
using Cars_Den.Models;
using Cars_Den.Repository.IRepository;

namespace Cars_Den.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Additional method to get all cars
        public IQueryable<Users> GetAllUsers()
        {
            return _context.Users;
        }
        public void Update(Users obj)
        {
            _context.Users.Update(obj);
        }
    }
}
