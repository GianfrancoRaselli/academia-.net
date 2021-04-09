using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        public enum Condiciones
        {
            Pendiente,
            Inscripto,
            Libre,
            Regular,
            Aprobada,
        }

        private Condiciones _condicion;
        public Condiciones Condicion
        {
            get
            {
                return _condicion;
            }
            set
            {
                _condicion = value;
            }
        }

        private Persona _alumno;
        public Persona Alumno
        {
            get
            {
                return _alumno;
            }
            set
            {
                _alumno = value;
            }
        }

        private string _nombreAlumno;
        public string NombreAlumno
        {
            get
            {
                return _nombreAlumno;
            }
            set
            {
                _nombreAlumno = value;
            }
        }

        private string _apellidoAlumno;
        public string ApellidoAlumno
        {
            get
            {
                return _apellidoAlumno;
            }
            set
            {
                _apellidoAlumno = value;
            }
        }

        private int _legajoAlumno;
        public int LegajoAlumno
        {
            get
            {
                return _legajoAlumno;
            }
            set
            {
                _legajoAlumno = value;
            }
        }

        private Curso _curso;
        public Curso Curso
        {
            get
            {
                return _curso;
            }
            set
            {
                _curso = value;
            }
        }

        private int _nota;
        public int Nota
        {
            get
            {
                return _nota;
            }
            set
            {
                _nota = value;
            }
        }

        public override string ToString()
        {
            return Alumno + " - " + Curso;
        }
    }
}
