using AutoMapper.QueryableExtensions;
using BookStore;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Book.Store.Presentation.Core
{
	public class AuthorRepo : Repositery<Author>, IAuthorRepo
	{
		private readonly BookStoreContext context;
		public AuthorRepo(BookStoreContext _context) : base(_context)
		{
			context = _context;
		}
		public List<AuthorModel> get(int id)
		{
			var res = context.Authors.Where(v=>v.Id==id).Select(x => new AuthorModel()
			{
				Name = x.Name,
				count = x.AuthorsBooks.Where(y => y.Author_ID == x.Id).Count(),
				totalPrice = x.AuthorsBooks.Where(y => y.Author_ID == x.Id).Sum(w => w.Book.Price),
				age=x.Age
            }).ToList();
			return res;
		}
	}
}
