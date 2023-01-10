using System.ComponentModel.DataAnnotations;

namespace Book.Store.Presentation
{
    public class SearchModel
    {
        public string Name { get; set; }
       
        public double Price { get; set; }

        public int Rating { get; set; }
        
        public int Cat_Id { get; set; }
       
        public int Author_Id { get; set; }
    }
}
