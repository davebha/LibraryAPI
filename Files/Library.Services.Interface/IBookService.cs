﻿using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IBookService
    {
        //CREATE
        Task<Book> AddBook(string title, int authorId);

        //READ
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetBookByName(string title);
        Task<IEnumerable<Book>> GetBookBetween(DateTime startDate,DateTime endDate);


        //UPDATE
        Task<Book> UpdateBookTitle(int id,string newTitle);
        Task<Book> UpdateIsAvailable(int id,bool newStatus);

        //DELETE
        Task RemoveBook(int id);
        //IEnumerable<Book> books
    }
}
