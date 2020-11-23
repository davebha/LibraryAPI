using Library.DataAccess.Interface;
using Library.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.UnitTests
{
    [TestFixture]
    public class AuthorServiceTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public  void Create_AuthorNameNullOrSpace_Fails(string badName)
        {
            //Arrange

            //Mock repository and create physical service to test
            Mock<IAuthorRepository> fakeRepository = new Mock<IAuthorRepository>();
            AuthorService authorService = new AuthorService(fakeRepository.Object);

            //Act
             authorService.Create(badName);

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => authorService.Create(badName));
        }
    }
}
