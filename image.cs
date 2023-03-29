using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisoraServer
{
    public class image
    {
        public int imageId { get; set; }
        public int mentorshipId { get; set; }   
        public int menteeId { get; set; }   
        public string imageURL { get; set; }
    }
}
