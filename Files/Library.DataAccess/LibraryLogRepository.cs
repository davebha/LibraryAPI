using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess.Interface;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess
{
    public class LibraryLogRepository : ILibraryLogRepository
    {
        public readonly LibraryDbContext _dbContext;

        public LibraryLogRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //CREATE
        public void AddLog(LibraryLog log)
        {
            _dbContext.LibraryLogs.Add(log);


        }

        //READ
        public async Task<IEnumerable<LibraryLog>> GetAll(){

            return await _dbContext.LibraryLogs.ToListAsync();

        }

        public async Task<LibraryLog> getLog(int _logId)
        {

            return await _dbContext.LibraryLogs.SingleOrDefaultAsync(g => g.Id == _logId);

        }


        //SAVE

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync(); 
        }
        

 
    }
}
