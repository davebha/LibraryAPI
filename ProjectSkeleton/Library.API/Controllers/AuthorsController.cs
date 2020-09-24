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

        public async Task<Author> Create(string title)
        {

        }
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorService.GetAll();
        }
    }
}
