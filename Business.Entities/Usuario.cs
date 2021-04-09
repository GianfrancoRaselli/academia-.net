using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private string _nombreUsuario;
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }

        private string _clave;
        public string Clave
        {
            get
            {
                return _clave;
            }
            set
            {
                _clave = value;
            }
        }

        private bool _habilitado;
        public bool Habilitado
        {
            get
            {
                return _habilitado;
            }
            set
            {
                _habilitado = value;
            }
        }

        private bool _cambiaClave;
        public bool CambiaClave
        {
            get
            {
                return _cambiaClave;
            }
            set
            {
                _cambiaClave = value;
            }
        }

        private Persona _persona;
        public Persona Persona
        {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
            }
        }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
