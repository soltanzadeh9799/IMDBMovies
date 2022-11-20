using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class MovieImageDAO : IMDBMoviesContext, IDAO<MovieImage, MovieImageDetailDTO>
    {
        public bool Delete(MovieImage entity)
        {
            if (entity.ID != 0)
            {
                MovieImage image = db.MovieImages.First(x => x.ID == entity.ID);
                db.MovieImages.Remove(image);
                db.SaveChanges();
                
            }
            return true;
        }

        public bool Insert(MovieImage entity)
        {
            try
            {
                db.MovieImages.Add(entity);
                db.SaveChanges();
                General.ImageID=entity.ID;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
      
        public List<MovieImageDetailDTO> Select()
        {
            List<MovieImageDetailDTO> movieimagedetail = new List<MovieImageDetailDTO>();
            var list = db.MovieImages.Where(x=>x.MovieID==General.MovieID);
            foreach (var item in list)
            {
                MovieImageDetailDTO dto = new MovieImageDetailDTO();
                dto.ID = item.ID;
                dto.MovieID = item.MovieID;
                dto.Images = item.Images;
                movieimagedetail.Add(dto);

            }
            
            return movieimagedetail;
        }

        public bool Update(MovieImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
