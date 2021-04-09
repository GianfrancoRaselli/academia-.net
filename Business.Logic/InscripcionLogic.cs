using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class InscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter alumnoInscripcionData;

        public InscripcionLogic()
        {
            alumnoInscripcionData = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetInscripcionesDelAlumno(Persona per)
        {
            return alumnoInscripcionData.GetInscripcionesDelAlumno(per);
        }

        public List<AlumnoInscripcion> GetInscripcionesDelCurso(Curso cur)
        {
            return alumnoInscripcionData.GetInscripcionesDelCurso(cur);
        }

        public void InscribirAlumno(int idPersona, int idCurso)
        {
            alumnoInscripcionData.Insert(idPersona, idCurso);
        }

        public void DesinscribirAlumno(int idPersona, int idCurso)
        {
            alumnoInscripcionData.Delete(idPersona, idCurso);
        }

        public void ActualizarNota(int idInscripcion, int nota)
        {
            alumnoInscripcionData.ActualizarNota(idInscripcion, nota);
        }
    }
}
