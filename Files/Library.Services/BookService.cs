using Library.DataAccess.Interface;
using Library.DomainModels;
using Library.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryLogRepository _libraryLogRepository;

        public BookService(IBookRepository bookRepository,ILibraryLogRepository libraryLogRepository)
        {
            _bookRepository = bookRepository;
            _libraryLogRepository = libraryLogRepository;
            

        }
     
       

        public async Task<Book>  AddBook(string title, int authorId)
        {
            if (authorId <= 0)
            {
                throw new ArgumentException("Author ID must be a positive integer greater than 0! ");
            }
            
             
            if(String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is mandatory!");
            }

            Book newBook = new Book() { Title = title, IsAvailable=true,AuthorId = authorId, CreatedOn = DateTime.Now };


            return await _bookRepository.AddBook(newBook);
        }

        //Get all books list using bookrepo and return it to controller
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }
  
        //Get a book using bookrepo through id and return it to controller
        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        //Get a book using bookrepo through title and return it to controller
        public async Task<IEnumerable<Book>> GetBookByName(string title)
        {
            return await _bookRepository.GetBookByName(title);
        }

        //Update changes  to specific field  will be done at service layer
        //The changes will be applied using repository layer

        public async Task<Book> UpdateBookTitle(int id, string newTitle)
        {
            //Do the validation

            
            if(id<=0)
            {
                throw new ArgumentException("id must be number greater than 0  ");
            }

            if (String.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Updated title name is required");
            }

            var book =await  GetBookById(id);
            book.Title = newTitle;

            
            return  await _bookRepository.UpdateBook(book);
           
        }

        public async Task<Book> UpdateIsAvailable(int id,bool newStatus)
        {
            //
            var book = await _bookRepository.GetBookById(id);
            book.IsAvailable = newStatus;


            LibraryLog log = new LibraryLog();
            log.BookId = id;
            log.Operation = Operations.Update;
            log.Date = DateTime.Now;

            _libraryLogRepository.AddLog(log);

            
            return await _bookRepository.UpdateBook(book);
         
        }

        //Remove book using id and add a log for it using unit of work principle
        public async Task RemoveBook(int id)
        {
             var book = await GetBookById(id);

            LibraryLog log = new LibraryLog();
            
            log.BookId = id;

            log.Operation = Operations.Delete;


            log.Date = DateTime.Now;

            _libraryLogRepository.AddLog(log);
            
            _bookRepository.RemoveBook(book);
           
            await _bookRepository.CommitChange();

        }

        //get the book list from bookrepo and return it to controller
        public async Task<IEnumerable<Book>> GetBookBetween(DateTime startDate, DateTime endDate)
        {

            return await _bookRepository.GetBookBetween(startDate, endDate);


        }

    }
}
