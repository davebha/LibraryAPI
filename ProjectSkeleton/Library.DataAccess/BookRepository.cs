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

        //CREATE

        public async Task<Book> AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;

        }

        //READ
        
        //Get Book using ID 
        public async Task<Book> GetBookById(int id)
        {

            return await _dbContext.Books.Include(a => a.Author).SingleOrDefaultAsync(d => d.Id == id);
        }

        //Get Book using title
        public async Task<IEnumerable<Book>> GetBookByName(string title)
        {
           
            return await _dbContext.Books.Where(b => b.Title.Contains(title)).ToListAsync();
                
        }


        //Get all the books from authors whose name is like X
        public async Task<IEnumerable<Book>> GetBooksWhereAuthorNameLike(string nameLike)
        {

            //Include author table in the query result
            List<Book> books = await _dbContext.Books.Include(a => a.Author).Where(b => b.Author.Name.Contains(nameLike)).ToListAsync();

            // Using Linq to SQL for explicit inner join
            IQueryable<Book> query = (from b in _dbContext.Books
                                      join a in _dbContext.Authors on b.AuthorId equals a.Id

                                      where a.Name.Contains(nameLike)

                                      select b);
            return books;
        }

        //Get books between specified range
        public async Task<IEnumerable<Book>> GetBookBetween(DateTime startDate, DateTime endDate)
        {
            List<Book> books = await _dbContext.Books.Where(d => d.CreatedOn.Date >= startDate.Date && d.CreatedOn.Date <= endDate.Date).ToListAsync();

            return books;

        }

        //Get all books in list
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        //UPDATE
        public async Task<Book> UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
           await _dbContext.SaveChangesAsync();
            return book;

        }

        //DELETE
        public  void RemoveBook(Book book)
        {

            _dbContext.Books.Remove(book);
             
       
           
        }
 
        public async Task CommitChange()
        {
            await _dbContext.SaveChangesAsync();
        }

       
       
    }
}
