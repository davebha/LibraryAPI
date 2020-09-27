using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IBookService
    {
        Task<Book> AddBook(string title, int authorId);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> GetBookByName(string title);
    }
}
