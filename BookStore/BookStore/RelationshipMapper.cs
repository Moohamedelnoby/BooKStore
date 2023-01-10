using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class RelationshipMapper
    {
        public static void MappRelationShips(this ModelBuilder builder)
        {
            builder.Entity<Books>()
                .HasOne(x=>x.Categories)
                .WithMany(x=>x.Books)
                .HasForeignKey(x=>x.Cat_Id)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AuthorsBooks>()
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.Author_ID)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AuthorsBooks>()
                .HasOne(x => x.Book)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.Book_ID)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }

    }
}
