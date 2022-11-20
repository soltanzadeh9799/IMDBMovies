using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DTO
{
    public class MovieDTO
    {
        public List<MoviesDetailDTO> Movies { get; set; }
        public List<CountryDetailDTO> Countries { get; set; }
        public List<ActorDetailDTO> Actores { get; set; }
        public List<GenreDetailDTO> Genres { get; set; }
        public List<LanguageDetailDTO> languages { get; set; }
        public List<WriterDetailDTO> Writers { get; set; }
     
    }
}
