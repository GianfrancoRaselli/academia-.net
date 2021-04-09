using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        DocenteCursoAdapter dca = new DocenteCursoAdapter();

        public List<Curso> GetCursos(int idDocente)
        {
            return dca.GetCursos(idDocente);
        }
    }
}
