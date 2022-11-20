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
    public class CountryBLL : IBLL<CountryDetailDTO, CountryDTO>
    {
        CountryDAO dao=new CountryDAO();
        public bool Delete(CountryDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CountryDetailDTO entity)
        {
           Country country = new Country();
            country.ID = entity.ID;
            country.CountryName=entity.CountryName;
            return dao.Insert(country);
        }

        public CountryDTO Select()
        {
            CountryDTO dto = new CountryDTO();
            dto.Countries = dao.Select();
            return dto;
        }

        public bool Update(CountryDetailDTO entity)
        {
            Country country = new Country();
            country.ID = entity.ID;
            country.CountryName = entity.CountryName;
            return dao.Update(country);
        }
    }
}
