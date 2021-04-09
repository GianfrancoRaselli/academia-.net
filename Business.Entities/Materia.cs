using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _descripcion;
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private int _hsSemanales;
        public int HsSemanales
        {
            get
            {
                return _hsSemanales;
            }
            set
            {
                _hsSemanales = value;
            }
        }

        private int _hsTotales;
        public int HsTotales
        {
            get
            {
                return _hsTotales;
            }
            set
            {
                _hsTotales = value;
            }
        }

        private Plan _plan;
        public Plan Plan
        {
            get
            {
                return _plan;
            }
            set
            {
                _plan = value;
            }
        }

        private string _descPlan;
        public string DescPlan
        {
            get
            {
                return _descPlan;
            }
            set
            {
                _descPlan = value;
            }
        }

        private List<MateriaCorrelativa> _materiasCorrelativas;
        public List<MateriaCorrelativa> MateriasCorrelativas
        {
            get
            {
                return _materiasCorrelativas;
            }
            set
            {
                _materiasCorrelativas = value;
            }
        }

        private AlumnoInscripcion.Condiciones _condicionAlumno;
        public AlumnoInscripcion.Condiciones CondicionAlumno
        {
            get
            {
                return _condicionAlumno;
            }
            set
            {
                _condicionAlumno = value;
            }
        }

        private int _notaAlumno;
        public int NotaAlumno
        {
            get
            {
                return _notaAlumno;
            }
            set
            {
                _notaAlumno = value;
            }
        }

        public override string ToString()
        {
            return Descripcion + " - " + Plan;
        }
    }
}