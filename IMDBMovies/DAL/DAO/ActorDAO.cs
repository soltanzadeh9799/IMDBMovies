using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBMovies.DAL.DAO
{
    public class ActorDAO : IMDBMoviesContext, IDAO<Actor, ActorDetailDTO>
    {
        public bool Delete(Actor entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Actor entity)
        {
            try
            {
                db.Actors.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ActorDetailDTO> Select()
        {
            List<ActorDetailDTO> actors = new List<ActorDetailDTO>();
            var list = (from a in db.Actors
                        join C in db.Countries on a.BirthPlace equals C.ID
                        select new
                        {
                            ID=a.ID,
                            Name=a.Name,
                            LastName=a.LastName,    
                            BirthDate=a.BirthDate,
                            BirthPlace=a.BirthPlace,
                            BirthPlaceName=C.CountryName,
                            Biography=a.Biography,
                            Image=a.Image
                        } ).OrderBy(x => x.ID).ToList();
            foreach (var item in list)
            {
                ActorDetailDTO dto = new ActorDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.LastName = item.LastName;
                dto.BirthDate = item.BirthDate;
                dto.BirthPlace = item.BirthPlace;
                dto.BirthPlaceName = item.BirthPlaceName;
                dto.Biography = item.Biography;
                dto.Image = item.Image;

                actors.Add(dto);
            }
            return actors;
        }

        public bool Update(Actor entity)
        {
            try
            {
                Actor actor = db.Actors.First(x => x.ID == entity.ID);
                actor.Name= entity.Name;
                actor.LastName= entity.LastName;
                actor.BirthDate = entity.BirthDate; 
                actor.BirthPlace = entity.BirthPlace;   
                actor.Image=entity.Image;
                actor.Biography=entity.Biography;
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
