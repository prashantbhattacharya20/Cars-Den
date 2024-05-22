using System.Linq;
namespace Cars_Den.Repository.IRepository

{
    //This interface helps UnitOfWork class in implementing all the methods of different repositories
    public interface IUnitOfWork
    {

        //Properties of all the repositories
        ICarsRepository CarsRepository { get; }
        IUsersRepository UsersRepository { get; }
        IBookingsRepository BookingsRepository { get; }

        //This method is used for saving changes to the database.
        void Save();
    }
}
