using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryEntities { get; }
        void SaveEntities(T t);
        void DeleteEntities(T t);
    }
}
