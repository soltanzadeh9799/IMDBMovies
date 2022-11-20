using IMDBMovies.DAL;
using IMDBMovies.DAL.DAO;
using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.BLL
{
    public class MovieBLL : IBLL<MoviesDetailDTO, MovieDTO>
    {
        MovieDAO dao=new MovieDAO();
        ActorDAO actordao=new ActorDAO();
        LanguageDAO languagedao=new LanguageDAO();
        CountryDAO countrydao=new CountryDAO();
        WriterDAO writerdao=new WriterDAO();
        GenreDAO genredao=new GenreDAO();

        public bool Delete(MoviesDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MoviesDetailDTO entity)
        {
            Movie movie = new Movie();
            movie.ID = entity.ID;
            movie.FilmName = entity.FilmName;
            movie.Director=entity.Director;
            movie.CountryID=entity.CountryID;
         //   movie.Rating=entity.Rating;
            movie.Rank=entity.Rank;
            movie.ReleaseDate=entity.ReleaseDate;
            movie.Poster=entity.Poster;
            movie.StoryLine=entity.StoryLine;
            return dao.Insert(movie);

        }

        public MovieDTO Select()
        {
            MovieDTO dto=new MovieDTO();
            dto.Movies = dao.Select();
            dto.Actores=actordao.Select();
            dto.Writers=writerdao.Select();
            dto.languages=languagedao.Select();
            dto.Countries=countrydao.Select();
            dto.Genres=genredao.Select();
            return dto;
        }

        public bool Update(MoviesDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        MovieDTO IBLL<MoviesDetailDTO, MovieDTO>.Select()
        {
            throw new NotImplementedException();
        }
    }
}
