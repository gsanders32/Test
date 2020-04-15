using BookAPI.Data;
using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Book Add(Book newBook)
        {
            _bookContext.Books.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }

        public Book Get(int id)
        {
            return _bookContext.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books.ToList();
        }

        public void Remove(Book removeBook)
        {
            Book currentBook = _bookContext.Books.FirstOrDefault(x => x.Id == removeBook.Id);
            if (currentBook != null)
            {
                _bookContext.Books.Remove(currentBook);
                _bookContext.SaveChanges();
            }
            else
            {
                throw new Exception("Cant find the Book");
            }
        }

        public Book Update(Book updateBook)
        {
            var currentBook = _bookContext.Books.Find(updateBook.Id);
            if (currentBook == null) return null;

            _bookContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updateBook);

            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }
    }
}
