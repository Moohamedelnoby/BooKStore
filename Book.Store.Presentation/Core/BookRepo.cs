using BookStore;
using Microsoft.EntityFrameworkCore;

namespace Book.Store.Presentation
{
    public class BookRepo : Repositery<Books>, IBookRepo
    {
        private readonly BookStoreContext context;
        public BookRepo(BookStoreContext _context) : base(_context)
        {
            context = _context;
        }
        //public override IEnumerable<Books> getAll()
        //{
        //    return context.Books.Include(x=>x.AuthorsBooks).
        //        ThenInclude(x=>x.FirstOrDefault().Author);

        //}
    }
}
