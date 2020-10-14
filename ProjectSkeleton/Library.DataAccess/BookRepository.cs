using Library.DataAccess.Interface;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;

        }

        

        public async Task<Book> GetBookById(int id)
        {

            return await _dbContext.Books.Include(a => a.Author).SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBookByName(string title)
        {
            //does not work here
            // return await _dbContext.Books.FindAsync(title);

            /*First => First element(at least 1 in list)
             * Throws exception if empty
             * FirstOrDefault => Like first method but brings designated "default"(i.e. null) value if empty
             */
            return await _dbContext.Books.Where(b => b.Title.Contains(title)).ToListAsync();
                //FirstAsync();
        }


        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }


    }
}
