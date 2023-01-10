using BookStore;

namespace Book.Store.Presentation
{
	public interface IAuthorRepo:IRepositery<Author>
	{
        public List<AuthorModel> get(int id);

    }
}
