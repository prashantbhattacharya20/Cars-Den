using Cars_Den.Models;
using Cars_Den.Repository.IRepository;
using System.Linq;

namespace Cars_Den.Repository.IRepository
{
    public interface IUsersRepository : IRepository<Users>
    {
        // Custom method to get all cars
        IQueryable<Users> GetAllUsers();

        void Update(Users obj);
    }
}
