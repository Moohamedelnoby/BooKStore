using BookStore;
using System.ComponentModel.DataAnnotations;

namespace Book.Store.Presentation
{
	public class BookModel
	{
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        
        public int Rating { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public int Cat_Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public List<int> Author_Id { get; set; }
     
    }
}
