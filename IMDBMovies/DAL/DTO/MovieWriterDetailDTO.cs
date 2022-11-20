using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DTO
{
    public class MovieWriterDetailDTO
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int WriterID { get; set; }
        public string MovieName { get; set; }
        public string WriterName { get; set; }

    }
}
