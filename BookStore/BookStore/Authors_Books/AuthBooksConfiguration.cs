using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class AuthBooksConfiguration : IEntityTypeConfiguration<AuthorsBooks>
    {
        public void Configure(EntityTypeBuilder<AuthorsBooks> builder)
        {
            builder.ToTable("Authors_Books");
            builder.HasKey(p=>new {p.Author_ID,p.Book_ID });
            

        }
    }
}
