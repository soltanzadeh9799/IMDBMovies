using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class GenreDAO : IMDBMoviesContext, IDAO<Genre, GenreDetailDTO>
    {
        public bool Delete(Genre entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Genre entity)
        {
            try
            {
                db.Genres.Add(entity);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            };
        }

        public List<GenreDetailDTO> Select()
        {
            List<GenreDetailDTO> genres = new List<GenreDetailDTO>();
            var list = db.Genres;
            foreach (var item in list)
            {
                GenreDetailDTO dto = new GenreDetailDTO();
                dto.ID = item.ID;
                dto.GenreName= item.GenreName;
                genres.Add(dto);

            }
            return genres;
        }

        public bool Update(Genre entity)
        {
            try
            {
                Genre genre = db.Genres.First(x => x.ID == entity.ID);
                genre.GenreName = entity.GenreName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
