using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ComisionLogic: BusinessLogic
    {
        private ComisionAdapter comisionData;

        public ComisionLogic()
        {
            comisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return comisionData.GetAll();
        }

        public Comision GetOne(int ID)
        {
            return comisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            comisionData.Delete(ID);
        }

        public void Update(Comision com)
        {
            comisionData.Update(com);
        }

        public void Insert(Comision com)
        {
            comisionData.Insert(com);
        }

        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }

            com.State = BusinessEntity.States.Unmodified;
        }
    }
}