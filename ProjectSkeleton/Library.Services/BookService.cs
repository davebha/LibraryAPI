using Library.DomainModels;
using Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        public Task<Book> AddBook(int AuthorId, string title)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }


    }
}
