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
        public async Task<Book> AddBook(int authorID,string title)
        {

            return await _bookService.AddBook(authorID, title);
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }




    }
}
