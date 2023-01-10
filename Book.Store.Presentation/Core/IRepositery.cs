using System.Linq.Expressions;

namespace Book.Store.Presentation
{
    public interface IRepositery<T> where T : class
    {
        IEnumerable<T> getAll();
        IEnumerable<T> getByParameter(Expression<Func<T,bool>> expression);

        T getById(int id);
        void AddNew(T entity);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(int id);
        void Save();

    }
}
