using Library.DataAccess.Interface;
using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class BookRepository : IBookRepository
    {
        public Task<Book> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }
    }
}
