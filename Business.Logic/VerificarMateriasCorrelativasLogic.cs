using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class VerificarMateriasCorrelativasLogic
    {
        public bool PuedeInscribirse(Persona per, Materia mat)
        {
            AlumnoInscripcionAdapter alumnoInscripcionData = new AlumnoInscripcionAdapter();
            List<AlumnoInscripcion> alumnoInscipciones = alumnoInscripcionData.GetInscripcionesDelAlumno(per);
            
            MateriaAdapter materiaData = new MateriaAdapter();
            Materia materia = materiaData.BuscarMateriaConCorrelativas(mat.ID);

            foreach(MateriaCorrelativa matCorr in materia.MateriasCorrelativas)
            {
                bool enCondiciones = false;

                foreach(AlumnoInscripcion alumnoInscripcion in alumnoInscipciones)
                {
                    if(matCorr.Condicion == MateriaCorrelativa.Condiciones.Regular && 
                        matCorr.MateriaPredecesora.ID == alumnoInscripcion.Curso.Materia.ID)
                    {
                        enCondiciones = true;
                        break;
                    }

                    if (matCorr.Condicion == MateriaCorrelativa.Condiciones.Aprobada &&
                        matCorr.MateriaPredecesora.ID == alumnoInscripcion.Curso.Materia.ID &&
                        alumnoInscripcion.Condicion == AlumnoInscripcion.Condiciones.Aprobada)
                    {
                        enCondiciones = true;
                        break;
                    }
                }

                if (!enCondiciones) return false;
            }

            return true;
        }
    }
}
