using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Cars_Den.Data;
using Cars_Den.Repository.IRepository;

namespace Cars_Den.Repository
{
    /*This class implements the IRepository interface and it is using generic implementation.*/
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        //Here we are initializing the _db and database context
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        //This method is used for adding entity to the database
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /*This method is used for fetching the data from database after filtering the conditions.*/
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

       //This method is used to get all the datas from the database and store it into the list
        public IEnumerable<T> GetAll()
        {
            IQueryable<T>  query = dbSet;
            return query.ToList();
        }

        /*This method is used for fetching all the datas which meet the conditions from database and stores all of them into the list.*/
        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        //This method is used for deleting the data from database.
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        //This method is used for deleting the data from database in certain range
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
