using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: use optionsBuilder to configure a Sqlite db
            optionsBuilder.UseSqlite("Data Source=book.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: configure some seed data in the books table
            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Nineteen Eighty-Four", Author = "George Orwell", Category = "Fiction" },
            new Book { Id = 2, Title = "Educated", Author = "Tara Westover", Category = "Non-fiction" },
            new Book { Id = 3, Title = "It", Author = "Stephen King", Category = "Horror" }
            );
        }
    }
}
