using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        private string _apellido;
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        private string _direccion;
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
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

        private int _legajo;
        public int Legajo
        {
            get
            {
                return _legajo;
            }
            set
            {
                _legajo = value;
            }
        }

        private string _telefono;
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        private DateTime _fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }

        public string FechaNacimientoConFormato
        {
            get
            {
                return _fechaNacimiento.ToString("dd/MM/yyyy");
            }
        }

        public int Edad
        {
            get
            {
                DateTime fechaActual = DateTime.Now;
                int edad = fechaActual.Year - this.FechaNacimiento.Year;
                if(fechaActual < this.FechaNacimiento.AddYears(edad))
                {
                    edad = edad - 1;
                }
                return edad;
            }
        }

        public enum TiposPersona
        {
            Administrativo,
            Docente,
            Alumno,
        }

        private TiposPersona _tipoPersona;
        public TiposPersona TipoPersona
        {
            get
            {
                return _tipoPersona;
            }
            set
            {
                _tipoPersona = value;
            }
        }

        public override string ToString()
        {
            return Legajo.ToString();
        }
    }
}