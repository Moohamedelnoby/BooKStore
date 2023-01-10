using BookStore;
using System.Linq.Expressions;

namespace Book.Store.Presentation
{
    public class Repositery<T> : IRepositery<T> where T : class
    {
        private BookStoreContext context;
        public Repositery(BookStoreContext _context)
        {
            context = _context;
        }

        public void AddNew(T entity)
        {
            if (entity != null)
             context.Set<T>().Add(entity);

        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  virtual IEnumerable<T> getAll()
        {
           return context.Set<T>().ToList();
        }

        public IEnumerable<T> getByParameter(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }

        public T getById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
