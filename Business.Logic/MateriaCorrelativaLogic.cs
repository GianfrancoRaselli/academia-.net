using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaCorrelativaLogic
    {
        private MateriaCorrelativaAdapter materiaCorrelativaData;

        public MateriaCorrelativaLogic()
        {
            materiaCorrelativaData = new MateriaCorrelativaAdapter();
        }

        public List<MateriaCorrelativa> GetAll()
        {
            return materiaCorrelativaData.GetAll();
        }

        public MateriaCorrelativa GetOne(int ID)
        {
            return materiaCorrelativaData.GetOne(ID);
        }       

        public void Save(MateriaCorrelativa mat)
        {
            switch (mat.State)
            {
                case MateriaCorrelativa.States.New:
                    Insert(mat);
                    break;
                case MateriaCorrelativa.States.Modified:
                    Update(mat);
                    break;
            }

            mat.State = BusinessEntity.States.Unmodified;
        }

        public void Insert(MateriaCorrelativa mat)
        {
            materiaCorrelativaData.Insert(mat);
        }

        public void Update(MateriaCorrelativa mat)
        {
            materiaCorrelativaData.Update(mat);
        }

        public void Delete(int ID)
        {
            materiaCorrelativaData.Delete(ID);
        }
    }
}
