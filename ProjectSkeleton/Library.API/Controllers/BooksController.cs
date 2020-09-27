using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DomainModels;
using Library.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<Book> AddBook(string title,int authorId)
        {
            return await _bookService.AddBook(title , authorId);
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }

        [HttpGet("id")]
        public async Task<Book> GetBookById(int id)
        {

            return await _bookService.GetBookById(id);
        }

        [HttpGet("title")]
        public async Task<Book> GetBookByName(string title)
        {
            return await _bookService.GetBookByName(title);
        }


    }
}
