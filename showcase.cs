using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisoraServer
{
    public class showcase
    {
        [Key]
        public int showcaseId { get; set; }
        public int mentorId { get; set; }
        public string image1 { get; set; } 
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image1Caption { get; set; }
        public string image2Caption { get; set; }
        public string image3Caption { get; set; }
        public string selfDescription { get; set; }

    }
}
