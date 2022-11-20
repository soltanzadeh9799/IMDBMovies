using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class MovieWriterDAO : IMDBMoviesContext, IDAO<MovieWriter, MovieWriterDetailDTO>
    {
        public bool Delete(MovieWriter entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MovieWriter entity)
        {
            try
            {
                db.MovieWriters.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MovieWriterDetailDTO> Select()
        {
            List<MovieWriterDetailDTO> MovieWriter = new List<MovieWriterDetailDTO>();
            var list = (from mw in db.MovieWriters
                       join m in db.Movies on mw.MovieID equals m.ID
                       join w in db.Writers on mw.WriterID equals w.ID
                       select new
                       {
                           ID=mw.ID,
                           MovieID=mw.MovieID,
                           WriterID=mw.WriterID,
                           MovieName=m.FilmName,
                           WriterName=w.WriterName
                       }).OrderBy(x => x.ID).ToList();
            foreach (var item in list)
            {
                MovieWriterDetailDTO dto = new MovieWriterDetailDTO();
                dto.ID = item.ID;
                dto.MovieName = item.MovieName;
                dto.WriterName = item.WriterName;
                dto.WriterID = item.WriterID;
                dto.MovieID=item.MovieID;
                MovieWriter.Add(dto);
            }
            return MovieWriter;
        }

        public bool Update(MovieWriter entity)
        {
            throw new NotImplementedException();
        }
    }
}
