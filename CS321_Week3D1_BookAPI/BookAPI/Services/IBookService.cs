using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface IBookService
    {
        Book Add(Book newBook);
        
        Book Get(int id);
        
        Book Update(Book updateBook);
        
        void Remove(Book removeBook);

        
        IEnumerable<Book> GetAll();
    }
}
}
