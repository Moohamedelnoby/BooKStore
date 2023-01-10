using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions options):base(options){ }
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<AuthorsBooks> AuthorsBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
            new CategoriesConfiguration().Configure(modelBuilder.Entity<Categories>());
            new BookConfiguration().Configure(modelBuilder.Entity<Books>());
            new AuthBooksConfiguration().Configure(modelBuilder.Entity<AuthorsBooks>());
            modelBuilder.MappRelationShips();
            modelBuilder.SeedingData();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder
            //    .UseSqlServer("Data Source=.; Initial Catalog= BookStore; Integrated Security=True;");
        }
    }
}
