using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter especialidadData;

        public EspecialidadLogic()
        {
            especialidadData = new EspecialidadAdapter();
        }

        public Especialidad GetOne(int ID)
        {
            return especialidadData.GetOne(ID);
        }

        public List<Especialidad> GetAll()
        {
            return especialidadData.GetAll();
        }

        public void Delete(int ID)
        {
            especialidadData.Delete(ID);
        }

        public void Update(Especialidad esp)
        {
            especialidadData.Update(esp);
        }

        public void Insert(Especialidad esp)
        {
            especialidadData.Insert(esp);
        }

        public void Save(Especialidad esp)
        {
            if (esp.State == BusinessEntity.States.New)
            {
                this.Insert(esp);
            }
            else if (esp.State == BusinessEntity.States.Modified)
            {
                this.Update(esp);
            }

            esp.State = BusinessEntity.States.Unmodified;
        }
    }
}
