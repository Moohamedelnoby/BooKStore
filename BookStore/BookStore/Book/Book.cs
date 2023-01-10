using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public  class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public int Cat_Id { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }


    }
}
