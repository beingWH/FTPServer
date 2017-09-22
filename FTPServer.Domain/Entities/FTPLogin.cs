using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.Entities
{
    public class FTPLogin
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string FtpServerIP { get;set; }
        [Required]
        public string FtpRemotePath { get; set; }
        [Required]
        public string FtpUserID { get; set; }
        [Required]
        public string FtpPassword { get; set; }
    }
}
