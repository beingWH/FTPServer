using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.Entities
{
    public class FTPFileAttr
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public bool IsDirectory { get; set; }

    }
}
