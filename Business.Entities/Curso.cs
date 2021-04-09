using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _anioCalendario;
        public int AnioCalendario
        {
            get
            {
                return _anioCalendario;
            }
            set
            {
                _anioCalendario = value;
            }
        }

        private int _cupos;
        public int Cupos
        {
            get
            {
                return _cupos;
            }
            set
            {
                _cupos = value;
            }
        }

        private int _cuposDisponibles;
        public int CuposDisponibles
        {
            get
            {
                return _cuposDisponibles;
            }
            set
            {
                _cuposDisponibles = value;
            }
        }

        private Comision _comision;
        public Comision Comision
        {
            get
            {
                return _comision;
            }
            set
            {
                _comision = value;
            }
        }

        private string _descComision;
        public string DescComision
        {
            get
            {
                return _descComision;
            }
            set
            {
                _descComision = value;
            }
        }

        private Materia _materia;
        public Materia Materia
        {
            get
            {
                return _materia;
            }
            set
            {
                _materia = value;
            }
        }

        private bool _comenzado;
        public bool Comenzado
        {
            get
            {
                return _comenzado;
            }
            set
            {
                _comenzado = value;
            }
        }

        public enum TiposCuatrimestre
        {
            Primero,
            Segundo,
            Anual,
        }

        private TiposCuatrimestre _tipoCuatrimestre;
        public TiposCuatrimestre TipoCuatrimestre
        {
            get
            {
                return _tipoCuatrimestre;
            }
            set
            {
                _tipoCuatrimestre = value;
            }
        }

        private string _condicionAlumno;
        public string CondicionAlumno
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

        public override string ToString()
        {
            return AnioCalendario + " - " + Materia.Descripcion + " - " + Comision;
        }
    }
}
