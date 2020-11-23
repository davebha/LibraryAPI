using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface ILibraryLogService
    {

        public Task<IEnumerable<LibraryLog>> GetLogs();

    }
}
