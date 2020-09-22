﻿using Library.DataAccess.Interface;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Author> Create(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return author;

        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _dbContext.Authors
                .ToListAsync();
        }
    }
}