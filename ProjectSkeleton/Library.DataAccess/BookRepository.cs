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


        // public async Task<IEnumerable<>>


        public async Task<Book> UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return book;

        }

        //PUT,DELETE

        //Remove book with book object
        public async Task RemoveBook(Book book)
        {

            _dbContext.Books.Remove(book);

            await _dbContext.SaveChangesAsync();
        }
 

        /*
         * Not realistic 
         */
        //IEnumerable<Book> books
        //REMOVE ALL BOOKS
        //public async Task RemoveAllBooks()
        //{
        //    List<Book>  books = (IEnumerable<Book>)GetAllBooks();
        //    _dbContext.Books.RemoveRange(books);
        //    //need saveChangesAsync to  execute any EF SQL commands 
        //     await _dbContext.SaveChangesAsync();
            
        //}


        //Returns books between specified range
        public async Task<IEnumerable<Book>> GetBookBetween(DateTime startDate, DateTime endDate)
        {
            List<Book> books =await _dbContext.Books.Where(d => d.CreatedOn.Date >= startDate.Date &&  d.CreatedOn.Date <= endDate.Date ).ToListAsync();

            return books;
           
        }



        //Get all the books from authors whose name is like X

        // SELECT books.* FROM BOOKS INNER JOIN Author   WHERE AUTHOR_NAME LIKE 'X';

        //Navigation property=>Object is part of another object

        //TASK<IENUMERABLE<X>> will allow returning of List,arrays
        //TASK<IQUERYABLE<X>> only good for wrapping logic to filter later
        public async  Task<IEnumerable<Book>> GetBooksWhereAuthorNameLike(string nameLike){
            

            List<Book> books = await _dbContext.Books.Include(a=>a.Author).Where(b => b.Author.Name.Contains(nameLike)).ToListAsync();

            // Using Linq to SQL for explicit inner join
            IQueryable<Book> query = (from b in _dbContext.Books
                                        join a in _dbContext.Authors on b.AuthorId equals a.Id

                                        where a.Name.Contains(nameLike)

                                        select b);

            return  books;
        }
        //IEnumerable
    }
}
