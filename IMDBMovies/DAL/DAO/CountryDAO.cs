using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class CountryDAO : IMDBMoviesContext, IDAO<Country, CountryDetailDTO>
    {
        public bool Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Country entity)
        {
            try
            {
                db.Countries.Add(entity);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            };
        }

        public List<CountryDetailDTO> Select()
        {
          
            List<CountryDetailDTO> countries = new List<CountryDetailDTO>();
            var list = db.Countries;
            foreach (var item in list)
            {
                CountryDetailDTO dto = new CountryDetailDTO();
                dto.ID=item.ID;
                dto.CountryName=item.CountryName;
                countries.Add(dto);

            }
            return countries;

        }

        public bool Update(Country entity)
        {
            try
            {
                Country Country = db.Countries.First(x => x.ID == entity.ID);
                Country.CountryName = entity.CountryName;
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
