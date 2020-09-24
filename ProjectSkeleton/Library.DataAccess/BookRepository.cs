using Library.DataAccess.Interface;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}
