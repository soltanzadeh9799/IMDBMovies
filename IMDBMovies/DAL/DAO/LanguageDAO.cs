using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class LanguageDAO : IMDBMoviesContext, IDAO<Language, LanguageDetailDTO>
    {
        public bool Delete(Language entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Language entity)
        {
            try
            {
                db.Languages.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LanguageDetailDTO> Select()
        {
            List<LanguageDetailDTO> languages = new List<LanguageDetailDTO>();
            var list = db.Languages;
            foreach (var item in list)
            {
                LanguageDetailDTO dto = new LanguageDetailDTO();
                dto.ID= item.ID;
                dto.LanguageName=item.LanguageName;
                languages.Add(dto);

            }
            return languages;
        }

        public bool Update(Language entity)
        {
            try
            {
                Language language = db.Languages.First(x => x.ID == entity.ID);
                language.LanguageName=entity.LanguageName;
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
