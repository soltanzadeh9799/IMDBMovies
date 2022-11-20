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
    public class WriterBLL : IBLL<WriterDetailDTO, WriterDTO>
    {
        WriterDAO dao = new WriterDAO();
        public bool Delete(WriterDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(WriterDetailDTO entity)
        {
            Writer writer = new Writer();
            writer.ID = entity.ID;  
            writer.WriterName=entity.WriterName;
            return dao.Insert(writer);
        }

        public WriterDTO Select()
        {
            WriterDTO dto=new WriterDTO();
            dto.Writers=dao.Select();
            return dto;
        }

        public bool Update(WriterDetailDTO entity)
        {
            Writer writer = new Writer();
            writer.ID = entity.ID;
            writer.WriterName = entity.WriterName;
            return dao.Update(writer);
        }
    }
}
