using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interface
{
    public interface IBookRepository
    {
        //CREATE
        Task<Book> AddBook(Book book);

        //READ
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBookByName(string title);
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetBookBetween(DateTime startDate, DateTime endDate);

        //UPDATE
        Task<Book> UpdateBook(Book book);

        //DELETE
        void RemoveBook(Book book);
        Task CommitChange();


       
        

       
       
    }
}
