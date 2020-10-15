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

        public async Task DeleteAuthorById(int id)
        {
             var author=await GetById(id);

            await _authorRepository.DeleteAuthorById(id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task<Author> GetByName(string name)
        {
            return await _authorRepository.GetByName(name);
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            //ValidationforName

            //String class has helper methods to operate on string values
            if (string.IsNullOrWhiteSpace(author.Name))
            {
                var exception = new Exception("Author name is mandatory");

                throw exception;
            }

            return await _authorRepository.UpdateAuthor(author);
        }

        public async Task<Author> UpdateIsAlive(int id, bool isAlive)
        {
            var author = await _authorRepository.GetById(id);

            author.IsAlive = isAlive;

            return await _authorRepository.UpdateAuthor(author);
        }
    }

}
