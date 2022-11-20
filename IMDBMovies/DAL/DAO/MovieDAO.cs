using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class MovieDAO : IMDBMoviesContext, IDAO<Movie, MoviesDetailDTO>
    {
        public bool Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Movie entity)
        {
            try
            {
                db.Movies.Add(entity);
                db.SaveChanges();
                General.MovieID=entity.ID;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MoviesDetailDTO> Select()
        {
           

            var movies = db.Movies.Select(M => new MoviesDetailDTO
            {
                ID = M.ID,
                FilmName = M.FilmName,
                Director = M.Director,
                ReleaseDate = M.ReleaseDate,
                CountryID = (int)M.CountryID,
                CountryName = db.Countries.Where(C => C.ID == M.CountryID).FirstOrDefault().CountryName,
                Poster = M.Poster,
                Rank = (int)M.Rank,
                //Rating = (decimal)M.Rating,
                StoryLine = M.StoryLine,
              
                ActorID = db.MovieActors.Where(w => w.MovieID == M.ID).Select(w => w.ActorID).ToList(),
                GenreID = db.MovieGenres.Where(G => G.MovieID == M.ID).Select(G => G.GenreID).ToList(),
                LanguageID = db.MovieLanguages.Where(L => L.MovieID == M.ID).Select(L => L.LanguageID).ToList(),
                WriterID = db.MovieWriters.Where(W => W.MovieID == M.ID).Select(W => W.WriterID).ToList(),
                ImageID = db.MovieImages.Where(I => I.MovieID == M.ID).Select(I => I.MovieID).ToList(),


            }).OrderBy(x => x.ID).ToList();

            return movies;
        }

        public bool Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
