using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class WriterDAO : IMDBMoviesContext, IDAO<Writer, WriterDetailDTO>
    {
        public bool Delete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Writer entity)
        {
            try
            {
                db.Writers.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<WriterDetailDTO> Select()
        {
            List<WriterDetailDTO> writers = new List<WriterDetailDTO>();
            var list = db.Writers;
            foreach (var item in list)
            {
                WriterDetailDTO dto= new WriterDetailDTO();
                dto.WriterName = item.WriterName;
                dto.ID=item.ID;
                writers.Add(dto);

            }
            return writers;

        }

        public bool Update(Writer entity)
        {
            try
            {
                Writer writer = db.Writers.First(x => x.ID == entity.ID);
                writer.WriterName = entity.WriterName;
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
