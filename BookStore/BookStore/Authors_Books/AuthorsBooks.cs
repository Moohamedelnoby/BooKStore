using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class AuthorsBooks
    {
        public int Book_ID { get; set; }
        public int Author_ID { get; set; }
        public virtual Books Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
