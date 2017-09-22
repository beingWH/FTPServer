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
    public class FileAttrRepository : IRepository<FTPFileAttr>
    {
        FTPDbContext context = new FTPDbContext();
        public IQueryable<FTPFileAttr> QueryEntities {
            get {
                return context.ftpFileAttrs;
            }
        }

        public void DeleteEntities(FTPFileAttr t)
        {
            using (FTPDbContext context = new FTPDbContext()) {
                FTPFileAttr dbEntry = context.ftpFileAttrs.Find(t.Id);
                if (dbEntry != null) {
                    context.ftpFileAttrs.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
        }

        public void SaveEntities(FTPFileAttr t)
        {
            using (FTPDbContext context = new FTPDbContext()) {
                if (t.Id == 0)
                {
                    context.ftpFileAttrs.Add(t);
                }
                else {
                    FTPFileAttr dbEntry = context.ftpFileAttrs.Find(t.Id);
                    if (dbEntry != null) {
                        dbEntry.Id = t.Id;
                        dbEntry.IsDirectory = t.IsDirectory;
                        dbEntry.Name = t.Name;
                        dbEntry.Path = t.Path;
                        dbEntry.CreateTime = t.CreateTime;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
