using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter usuarioData;

        public Usuario ValidarUsuario(Usuario user)
        {
            return usuarioData.BuscarPorUsuarioYContrasenia(user);
        }

        public UsuarioLogic()
        {
            usuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int ID)
        {
            return usuarioData.GetOne(ID);
        }

        public Usuario BuscarPorLegajo(int legajo)
        {
            return usuarioData.BuscarPorLegajo(legajo);
        }

        public List<Usuario> GetAll()
        {
            return usuarioData.GetAll();
        }

        public void Delete(int ID)
        {
            usuarioData.Delete(ID);
        }

        public void Update(Usuario user)
        {
            usuarioData.Update(user);
        }

        public void Insert(Usuario user)
        {
            usuarioData.Insert(user);
        }

        public void Save(Usuario user)
        {
            if (user.State == BusinessEntity.States.New)
            {
                this.Insert(user);
            }
            else if(user.State == BusinessEntity.States.Modified)
            {
                this.Update(user);
            }

            user.State = BusinessEntity.States.Unmodified;
        }
    }
}
