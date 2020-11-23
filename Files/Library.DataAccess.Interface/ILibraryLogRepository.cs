using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interface
{
    public interface ILibraryLogRepository
    {
        //CREATE
        public void AddLog(LibraryLog log);

        //READ

        public Task<IEnumerable<LibraryLog>> GetAll();

        public  Task<LibraryLog> getLog(int _logId);



        //SAVE

        public Task Commit();


    }
}
