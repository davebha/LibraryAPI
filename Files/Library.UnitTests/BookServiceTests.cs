﻿using Library.DataAccess.Interface;
using Library.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.UnitTests
{
    [TestFixture]
    public class BookServiceTests
    {
        //nunit, xunit -> Not specific ones

        //Naming convention for a test: Name of the method to test[i.e. AddBook_[Scenerio(i.e.InvalidAuthorId)]_[Expected Result(i.e.Exception)]


        //Arrange Act Assert is good practice
        [TestCase("Harry Potter",-1)]
        [TestCase("Cirque du Soleil",0)]
        [TestCase("Watchmen",-3)]
        public async Task AddBook_InvalidAuthorId_Exception(string title,int badId) {

            //Arrange->Preparing variables and objects for tests
            Mock<IBookRepository> fakeBookRepo = new Mock<IBookRepository>();
            Mock<ILibraryLogRepository> fakeLogRepo = new Mock<ILibraryLogRepository>();
            BookService bookService = new BookService(fakeBookRepo.Object,fakeLogRepo.Object);
           
            //Act->Calling all methods
            await bookService.AddBook(title, badId);

            //Assert->Verify result
            Assert.ThrowsAsync<ArgumentException>(() => bookService.AddBook(title,badId));

        }

    }
}
