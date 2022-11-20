using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DTO
{
    public class MoviesDetailDTO
    {
        public byte[] Poster { get; set; }
        public int ID { get; set; }
        public string FilmName { get; set; }
        public string Director { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Rank { get; set; }
        public decimal Rating { get; set; }
        public string StoryLine { get; set; }
        public DateTime? Runtime { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public List<int> ActorID { get; set; }
        public List<int> WriterID { get; set; }
        public List<int> GenreID { get; set; }
        public List<int> LanguageID { get; set; }
        public List<int> ImageID { get; set; }


    }
}
