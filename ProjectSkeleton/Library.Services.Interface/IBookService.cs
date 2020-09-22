using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IBookService
    {
        Task<Book> AddBook(Author author, string title);
        Task<IEnumerable<Book>> GetAllBooks();

    }
}
