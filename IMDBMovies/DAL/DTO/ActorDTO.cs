using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DTO
{
    public class ActorDTO
    {
        public List<ActorDetailDTO> Actores { get; set; }
        public List<CountryDetailDTO> Countries { get; set; }
    }
}
