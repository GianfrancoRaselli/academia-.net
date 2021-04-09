using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Xml.Linq;

namespace Business.Logic
{
    public class MateriaLogic: BusinessLogic
    {
        public MateriaAdapter materiaData;

        public MateriaLogic()
        {
            materiaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return materiaData.GetAll();
        }

        public List<Materia> GetMateriasDelPlan(Plan plan)
        {
            return materiaData.GetMateriasDelPlan(plan);
        }

        public List<Materia> BuscarMateriasCorrelativasDeLaMateria(Materia mat)
        {
            return materiaData.BuscarMateriasCorrelativasDeLaMateria(mat);
        }

        public Materia GetOne(int ID)
        {
            return materiaData.GetOne(ID);
        }

        public Materia BuscarMateriaConCorrelativas(int ID)
        {
            return materiaData.BuscarMateriaConCorrelativas(ID);
        }

        public void Delete(int ID)
        {
            materiaData.Delete(ID);
        }

        public void Update(Materia mat)
        {
            materiaData.Update(mat);
        }

        public void Insert(Materia mat)
        {
            materiaData.Insert(mat);
        }

        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            else if(mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }

            mat.State = BusinessEntity.States.Unmodified;
        }
    }
}
