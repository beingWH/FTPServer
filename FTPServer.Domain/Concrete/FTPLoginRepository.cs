using FTPServer.Abstract;
using FTPServer.Entities;
using FTPServer.FTPContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.Domain.Concrete
{
    public class FTPLoginRepository:IRepository<FTPLogin>
    {
        FTPDbContext context = new FTPDbContext();
        public IQueryable<FTPLogin> QueryEntities {
            get {
                return context.ftpLogins;
            }
        }

        public void DeleteEntities(FTPLogin t)
        {
            throw new NotImplementedException();
        }

        public void SaveEntities(FTPLogin t)
        {
            throw new NotImplementedException();
        }
    }
}
