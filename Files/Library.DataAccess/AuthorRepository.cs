using Library.DataAccess.Interface;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;
        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create an instance of author
        public async Task<Author> Create(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return author;

        }

        //Delete author by given ID
        public async Task<int> DeleteAuthorById(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            _dbContext.Authors.Remove(author);
           return  await _dbContext.SaveChangesAsync();
            
        }

        //Get all the authors
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _dbContext.Authors
                .ToListAsync();
        }

        //Get author by ID
        public async Task<Author> GetById(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
            
        }

        //Get author by name
        public async Task<Author> GetByName(string name)
        {
            
            return await _dbContext.Authors.Where(a => a.Name.Contains(name)).SingleOrDefaultAsync();

        }


        //Update a specific author
        public async Task<Author> UpdateAuthor(Author author)
        {
           _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();

            return author;
           
        }
    }
}
