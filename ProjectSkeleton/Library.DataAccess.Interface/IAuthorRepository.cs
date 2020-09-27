using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> Create(Author author);
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> GetByName(string name);
    }
}
