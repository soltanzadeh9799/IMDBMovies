using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DTO
{
    public class MovieImageDetailDTO
    {
        
        public int ID { get; set; }
        public int MovieID { get; set; }
        public byte[] Images { get; set; }
    }
}
