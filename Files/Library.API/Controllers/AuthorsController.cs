using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DomainModels;
using Library.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<Author> Create(string name)
        {
            return await _authorService.Create(name);
        }
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorService.GetAll();
        }

        [HttpGet("id")] 
        public async Task<Author> GetById(int id)
        {
            return await _authorService.GetById(id);
        
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName(string name)
        {
            var author = await _authorService.GetByName(name);
            return Ok(author);
            // return await _authorService.GetByName(name);

        }

        /*HttpPut expects whole object
         * HttpPatch expects only few properties
         */
        [HttpPut("author")]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            var newAuthor = await _authorService.UpdateAuthor(author);

            return Ok(newAuthor);
        }

        [HttpPatch("isAlive")]
        public async Task<IActionResult> UpdateIsAlive (int id,bool isAlive)
        {

            var newAuthor = await _authorService.UpdateIsAlive(id, isAlive);

            return Ok(newAuthor);



        }

        //ADD GET CHANGE REMOVE



        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAuthorById(int id)
        {
             await _authorService.DeleteAuthorById(id);
            return Ok();
        }





    }
}
