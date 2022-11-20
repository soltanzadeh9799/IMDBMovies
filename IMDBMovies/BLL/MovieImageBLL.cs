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
    public class MovieImageBLL : IBLL<MovieImageDetailDTO, MovieImagesDTO>
    {
        MovieImageDAO dao=new MovieImageDAO();
        public bool Delete(MovieImageDetailDTO entity)
        {
            MovieImage movieImage = new MovieImage();
            movieImage.ID=entity.ID;
            return dao.Delete(movieImage);
        }

        public bool Insert(MovieImageDetailDTO entity)
        {
           MovieImage movieImage = new MovieImage();
            movieImage.ID = entity.ID;
            movieImage.MovieID = entity.MovieID;
            movieImage.Images=entity.Images;
            return dao.Insert(movieImage);
        }

        public MovieImagesDTO Select()
        {
            MovieImagesDTO movieImagesDTO = new MovieImagesDTO();
            movieImagesDTO.movieImageDetailDTOs = dao.Select();
            return movieImagesDTO;
        }

        public bool Update(MovieImageDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
