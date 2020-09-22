using Library.DataAccess.Interface;
using Library.DomainModels;
using Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;  
        }

        public async Task<Author> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Author name is mandatory");

            Author newAuthor = new Author()
            {
                Name = name
            };

            return await _authorRepository.Create(newAuthor);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }
    }
}
