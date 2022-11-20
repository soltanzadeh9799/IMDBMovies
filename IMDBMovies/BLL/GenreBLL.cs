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
    public class GenreBLL : IBLL<GenreDetailDTO, GenreDTO>
    {
        GenreDAO dao = new GenreDAO();
        public bool Delete(GenreDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(GenreDetailDTO entity)
        {
            Genre genre = new Genre();
            genre.ID = entity.ID;
            genre.GenreName= entity.GenreName;
            return dao.Insert(genre);
        }

        public GenreDTO Select()
        {
            GenreDTO dto = new GenreDTO();
            dto.Genres = dao.Select();
            return dto;
            
        }

        public bool Update(GenreDetailDTO entity)
        {
            Genre genre = new Genre();
            genre.ID = entity.ID;
            genre.GenreName = entity.GenreName;
            return dao.Update(genre);
        }
    }
}
