using System.Linq.Expressions;

namespace Cars_Den.Repository.IRepository
{
    //This class implements all the basic methods which are required
    public interface IRepository<T> where T : class
    {
        //This method gets all datas of type T from database
        IEnumerable<T> GetAll();

        //This method gets all datas of type T from database which satisfy the conditions
        IEnumerable<T> GetAll(Func<T, bool> predicate);

        //This method get the data from database which satisify the criteria
        T Get(Expression<Func<T,bool>>filter);
        
        //This method add the data to the database.
        void Add(T entity);
       
        //This method delete the data from the database
        void Remove(T entity);

        //This method remove the datas from the database in certain range.
        void RemoveRange(IEnumerable<T> entity);

    }
}
