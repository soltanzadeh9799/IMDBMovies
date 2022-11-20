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
    public class LanguageBLL : IBLL<LanguageDetailDTO, LanguageDTO>
    {
        LanguageDAO dao= new LanguageDAO();
        public bool Delete(LanguageDetailDTO entity)
        {

            throw new NotImplementedException();
        }

        public bool Insert(LanguageDetailDTO entity)
        {
            Language language = new Language();
            language.ID = entity.ID;
            language.LanguageName = entity.LanguageName;
            return dao.Insert(language);

        }

        public LanguageDTO Select()
        {
            LanguageDTO dto = new LanguageDTO();
            dto.languages = dao.Select();
            return dto;
        }

        public bool Update(LanguageDetailDTO entity)
        {
            Language language = new Language();
            language.ID = entity.ID;
            language.LanguageName = entity.LanguageName;
            return dao.Update(language);
        }
    }
}
