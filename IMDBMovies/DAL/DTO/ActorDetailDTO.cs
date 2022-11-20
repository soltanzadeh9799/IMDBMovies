using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DTO
{
    public class ActorDetailDTO
    {
        public byte[] Image { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? BirthPlace { get; set; }
        public string BirthPlaceName { get; set; }
        public string Biography { get; set; }
       // public bool IsCheck { get; set; }

    }
}
