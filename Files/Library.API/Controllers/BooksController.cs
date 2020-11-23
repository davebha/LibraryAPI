using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DomainModels;
using Library.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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

        //[HttpGet("createdOnDate")]
        //public async  Task<IEnumerable<Book>> GetBookByDate(DateTime createdOnDate)
        //{
        //    return await _bookService.GetBookByDate(createdOnDate);
        //}

        //UPDATE

        [HttpPatch("id")]
        public async Task<Book> UpdateBookTitle(int id,string newTitle)
        {

            return await _bookService.UpdateBookTitle(id,newTitle);

        }
    
        [HttpPatch]
        public async Task<Book> UpdateIsAvailable(int id,bool newStatus)
        {
            return await _bookService.UpdateIsAvailable(id,newStatus);

        }



        //DELETE 




        //Delete with id parameter
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _bookService.GetBookById(id);
            return Ok();
        }

      
    }
}
