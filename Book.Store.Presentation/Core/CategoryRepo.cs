using BookStore;

namespace Book.Store.Presentation.Core
{
	public class CategoryRepo : Repositery<Categories>, ICategoryRepo
	{
		public CategoryRepo(BookStoreContext _context) : base(_context)
		{
		}
	}
}
