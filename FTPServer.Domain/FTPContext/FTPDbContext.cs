using FTPServer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.FTPContext
{
    public class FTPDbContext : DbContext
    {
        public FTPDbContext() : base("FTPConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<FTPDbContext>(new DropCreateDatabaseIfModelChanges<FTPDbContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FTPLogin> ftpLogins { get; set; }
        public DbSet<FTPFileAttr> ftpFileAttrs { get; set; }

    }
}
