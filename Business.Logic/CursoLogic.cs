using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter cursoData;

        public CursoLogic()
        {
            cursoData = new CursoAdapter();
        }

        public Curso GetOne(int ID)
        {
            return cursoData.GetOne(ID);
        }

        public List<Curso> GetAll()
        {
            return cursoData.GetAll();
        }

        public List<Curso> GetCursosDeLaMateriaDisponibles(Materia materia)
        {
            return cursoData.GetCursosDeLaMateriaDisponibles(materia);
        }

        public List<Curso> GetCursosDelDocente(Persona per)
        {
            return cursoData.GetCursosDelDocente(per);
        }

        public void Delete(int ID)
        {
            cursoData.Delete(ID);
        }

        public void Update(Curso curso)
        {
            cursoData.Update(curso);
        }

        public void Insert(Curso curso)
        {
            cursoData.Insert(curso);
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }

            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}