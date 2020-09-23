using Library.DataAccess.Interface;
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
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;


        }
        public Task<Book> AddBook(int AuthorId, string title)
        {


            //Set IsAvailable to true
            //- CreatedOn = DateTime.Now
            //- Title must be at least 3 characters long
            //-AuthorId > 0
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }


    }
}
