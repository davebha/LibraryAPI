using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interface
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);


        Task<IEnumerable<Book>> GetAllBooks();


        Task<IEnumerable<Book>> GetBookByName(string title);



        Task<Book> GetBookById(int id);


        Task<IEnumerable<Book>> GetBookBetween(DateTime startDate, DateTime endDate);



        Task<Book> UpdateBook(Book book);

      
        Task RemoveBook(Book book);


        //IEnumerable<Book> books

        Task RemoveAllBooks();

       
        

       
       
    }
}
