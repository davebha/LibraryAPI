using Library.DataAccess;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.UnitTests
{
    [TestFixture]
    public class BookRepositoryTests
    {
        [Test]
        public void GetByName_Return_Title() {

            Mock<DbContextOptions<LibraryDbContext>> dbContextOptions = new Mock<DbContextOptions<LibraryDbContext>>();
            Mock<LibraryDbContext> dbContextLibrary = new Mock<LibraryDbContext>(dbContextOptions.Object);

            Book b = new Book() {Id=1,Title="Harry Potter 1" };
            Book b2 = new Book() { Id = 2, Title = "Harry Potter 2" };
            Book b3 = new Book() { Id = 3, Title = "Harry Potter 3" };
            Book b4 = new Book() { Id = 4, Title = "Book of Ice and Fire" };
            IQueryable<Book>  dbTableBook = new List<Book> { b, b2, b3, b4 }.AsQueryable();
            Mock<DbSet<Book>> dbSetOfBooks = new Mock<DbSet<Book>>();
           



        }

    }
}
