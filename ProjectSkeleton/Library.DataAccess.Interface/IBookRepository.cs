using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interface
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book);

        Task<IEnumerable<Book>> GetAll();

    }
}
