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

        //Create a new author
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

        //Delete author using Id in repository
        public async Task DeleteAuthorById(int id)
        {
             var author=await GetById(id);

            await _authorRepository.DeleteAuthorById(id);
        }

        //Get list of all authors from repository layer and return it to controller
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        //Same as GetAll but just a single author and needs author ID
        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }

        //Same as GetById but needs author name instead of ID
        public async Task<Author> GetByName(string name)
        {
            return await _authorRepository.GetByName(name);
        }

        //UpdateAuthor object
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


        //Update the isAlive property
        public async Task<Author> UpdateIsAlive(int id, bool isAlive)
        {
            var author = await _authorRepository.GetById(id);

               author.IsAlive = isAlive;

            return await _authorRepository.UpdateAuthor(author);
        }
    }

}
