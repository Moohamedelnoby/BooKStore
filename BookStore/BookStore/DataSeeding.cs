using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class DataSeeding
    {
        public static void SeedingData(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Author>()
                .HasData(
                new Author() {Id=1, Name="Ali",Age=50},
                new Author() { Id = 2, Name = "Ahmed", Age = 30 },
                new Author() { Id = 3, Name = "Mohamed", Age = 35 },
                new Author() { Id = 4, Name = "Sameh", Age = 40 }
                );
            modelBuilder.Entity<Categories>()
                .HasData(
                new Categories() {CategoryID=1, CategoryName="History" },
                new Categories() { CategoryID = 2, CategoryName ="Programing" },
                new Categories() { CategoryID = 3, CategoryName ="Medicla" },
                new Categories() { CategoryID = 4, CategoryName ="Sports" }
                );
        }
    }
}
