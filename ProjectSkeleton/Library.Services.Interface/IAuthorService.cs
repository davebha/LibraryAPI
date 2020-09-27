using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IAuthorService
    {
        Task<Author> Create(string name);
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> GetByName(string name);
    }
}
