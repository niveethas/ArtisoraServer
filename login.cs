using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisoraServer
{
    public class login
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
