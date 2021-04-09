using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter personaData;

        public PersonaLogic()
        {
            personaData = new PersonaAdapter();
        }

        public Persona GetOne(int ID)
        {
            return personaData.GetOne(ID);
        }

        public List<Persona> GetAll()
        {
            return personaData.GetAll();
        }

        public List<Persona> GetAlumnos()
        {
            return personaData.GetAlumnos();
        }

        public List<Persona> GetPersonasDisponibles()
        {
            return personaData.GetPersonasDisponibles();
        }

        public void Delete(int ID)
        {
            personaData.Delete(ID);
        }

        public void Update(Persona pers)
        {
            personaData.Update(pers);
        }

        public void Insert(Persona pers)
        {
            personaData.Insert(pers);
        }

        public void Save(Persona pers)
        {
            if (pers.State == BusinessEntity.States.New)
            {
                this.Insert(pers);
            }
            else if (pers.State == BusinessEntity.States.Modified)
            {
                this.Update(pers);
            }

            pers.State = BusinessEntity.States.Unmodified;
        }
    }
}
