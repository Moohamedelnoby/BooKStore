using AutoMapper;
using Book.Store.Presentation.Core;
using BookStore;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Book.Store.Presentation
{
    public class BookController : Controller
    {

        private readonly IBookRepo _bookRepo;
        private readonly IAuthorRepo _authorRepo;
        private readonly ICategoryRepo _categoryRepo;
        public BookController(IBookRepo bookRepo,
            
            IAuthorRepo authorRepo,
            ICategoryRepo categoryRepo) 
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _categoryRepo=categoryRepo;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Books = _bookRepo.getAll();
            ViewBag.Authors = _authorRepo.getAll();
            ViewBag.Categories = _categoryRepo.getAll();
            

            return View();
        }
        [HttpGet]
        public IActionResult AuthorDetails(int id)
        {
            ViewBag.AuthorDetails = _authorRepo.get(id);
            return View();
        }
        [HttpGet]
        public IActionResult Search(SearchModel model)
        {
            if(model==null)
            {
                ViewBag.Authors = _authorRepo.getAll();
                ViewBag.Categories = _categoryRepo.getAll();
                ViewBag.FilteredBooks = _bookRepo.getAll();
                return View();
            }
            else
            {
                ViewBag.Authors = _authorRepo.getAll();
                ViewBag.Categories = _categoryRepo.getAll();

                ViewBag.FilteredBooks = _bookRepo.
                    getByParameter(x =>(model.Name==null || x.Name.Contains(model.Name))
                    && (model.Price==0 || x.Price==model.Price)
                    && (model.Rating==0 || x.Rating==model.Rating)
                    &&(model.Cat_Id==0 || x.Cat_Id==model.Cat_Id)
                    &&(model.Author_Id==0 || x.AuthorsBooks.Select(y=>y.Author_ID).Where(f=>f==model.Author_Id).Count()!=0));
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Authors = _authorRepo.getAll();
            ViewBag.Categories = _categoryRepo.getAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookModel bookModel)
        {
            if(ModelState.IsValid==false)
            {
                ViewBag.Authors= _authorRepo.getAll();
                ViewBag.Categories = _categoryRepo.getAll();
                return View();
            }
            else
            {
                if(bookModel!=null)
                {
                    var authbook = new List<AuthorsBooks>();
                    foreach (var item in bookModel.Author_Id)
                    {
                        authbook.Add(new AuthorsBooks { Author_ID = item });
                    }
                    var book = new Books
                    {
                        Name = bookModel.Name,
                        Description = bookModel.Description,
                        Price = bookModel.Price,
                        Cat_Id = bookModel.Cat_Id,
                        AuthorsBooks = authbook,
                        Rating = bookModel.Rating

                    };
                    
                    _bookRepo.AddNew(book);
                    _bookRepo.Save();
                    return RedirectToAction("Index");

                }
                return RedirectToAction("Index");

            }
        }

    }
}
