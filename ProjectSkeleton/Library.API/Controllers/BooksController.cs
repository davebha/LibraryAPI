using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DomainModels;
using Library.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //CREATE
        [HttpPost]
        public async Task<Book> AddBook(string title,int authorId)
        {
            return await _bookService.AddBook(title , authorId);
        }

        //[HttpPost]
        //[Route("api/books")]
        //public async Task<IActionResult> CreateBook([FromBody]Book passedBook)
        //{
        //    var book = await _bookService.AddBook(passedBook.Title,passedBook.AuthorId);

        //    return Ok(book);
        //}



        //READ
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpGet("title")]
        public async Task<IEnumerable<Book>> GetBookByName(string title)
        {
            return await _bookService.GetBookByName(title);
        }

        [HttpGet("createdOnDate")]
        public async  Task<IEnumerable<Book>> GetBookByDate(DateTime createdOnDate)
        {
            return await _bookService.GetBookByDate(createdOnDate);
        }

        //UPDATE


        public async Task<Book> UpdateBookTitle(string newTitle)
        {

            return await _bookService.UpdateBookTitle(newTitle);

        }
    

        public async Task<Book> UpdateIsAvailable(bool newStatus)
        {
            return await _bookService.UpdateIsAvailable(newStatus);

        }



        //DELETE 




        //Delete with id parameter
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _bookService.GetBookById(id);
            return Ok();
        }

        //DeleteAll
        [HttpDelete]
        public async Task RemoveAllBooks()
        {
             await _bookService.RemoveAllBooks();

        }
    }
}
