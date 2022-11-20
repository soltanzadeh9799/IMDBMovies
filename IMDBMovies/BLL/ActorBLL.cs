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
    public class ActorBLL : IBLL<ActorDetailDTO, ActorDTO>
    {
        ActorDAO dao = new ActorDAO();
        CountryDAO countrydao = new CountryDAO();
        public bool Delete(ActorDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ActorDetailDTO entity)
        {
           Actor actor = new Actor();
            actor.ID = entity.ID;
            actor.Name = entity.Name;
            actor.LastName = entity.LastName;
            actor.BirthPlace = entity.BirthPlace;
            actor.BirthDate=entity.BirthDate;
            actor.Biography=entity.Biography;
            actor.Image = entity.Image;
            return dao.Insert(actor);
        }

        public ActorDTO Select()
        {
            ActorDTO dto = new ActorDTO();
            dto.Actores = dao.Select();
            dto.Countries = countrydao.Select();
            return dto;
        }

        public bool Update(ActorDetailDTO entity)
        {
            Actor actor = new Actor();
            actor.ID = entity.ID;
            actor.Name = entity.Name;
            actor.LastName = entity.LastName;
            actor.BirthPlace = entity.BirthPlace;
            actor.BirthDate = entity.BirthDate;
            actor.Biography = entity.Biography;
            actor.Image = entity.Image;
            return dao.Update(actor);
        }
    }
}
