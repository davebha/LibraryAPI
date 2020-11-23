using Library.DataAccess.Interface;
using Library.DomainModels;
using Library.Services.Interface;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class LibraryLogService : ILibraryLogService
    {
        private readonly ILibraryLogRepository _libraryLogService;
      
        public LibraryLogService(ILibraryLogRepository libraryLogService)
        {
            _libraryLogService = libraryLogService;
        }

     


        public async Task<IEnumerable<LibraryLog>> GetLogs()
        {
            return await _libraryLogService.GetAll();
        }
    }
}
