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
    public class MovieWriterBLL : IBLL<MovieWriterDetailDTO, MovieWriterDTO>
    {
        MovieWriterDAO dao = new MovieWriterDAO();
        public bool Delete(MovieWriterDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MovieWriterDetailDTO entity)
        {
            MovieWriter movieWriter = new MovieWriter();
            movieWriter.WriterID = entity.WriterID;
            movieWriter.MovieID = entity.MovieID;
            return dao.Insert(movieWriter);
        }

        public MovieWriterDTO Select()
        {
            MovieWriterDTO dto = new MovieWriterDTO();
            dto.movieWriterDetails = dao.Select();
            return dto;
        }

        public bool Update(MovieWriterDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
