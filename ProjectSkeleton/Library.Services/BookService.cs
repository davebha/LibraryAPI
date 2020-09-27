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

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;


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

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<Book> GetBookByName(string title)
        {
            return await _bookRepository.GetBookByName(title);
        }
    }
}
