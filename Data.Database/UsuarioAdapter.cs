using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public Usuario BuscarPorUsuarioYContrasenia(Usuario user)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario=@nombre_usuario COLLATE SQL_Latin1_General_CP1_CS_AS " +
                    "and clave=@clave COLLATE SQL_Latin1_General_CP1_CS_AS", SqlConn);
                cmd.Parameters.Add("@nombre_usuario", System.Data.SqlDbType.VarChar).Value = user.NombreUsuario;
                cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = user.Clave;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    PersonaAdapter PersonaData = new PersonaAdapter();

                    user.ID = (int)dr["id_usuario"];
                    user.NombreUsuario = (string)dr["nombre_usuario"];
                    user.Clave = (string)dr["clave"];
                    user.Habilitado = (bool)dr["habilitado"];
                    user.CambiaClave = (bool)dr["cambia_clave"];
                    user.Persona = PersonaData.GetOne((int)dr["id_persona"]);
                }
                else
                {
                    user = null;
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return user;
        }

        public List<Usuario> GetAll()
        {
            PersonaAdapter PersonaData = new PersonaAdapter();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Usuario user = new Usuario();

                    user.ID = (int)dr["id_usuario"];
                    user.NombreUsuario = (string)dr["nombre_usuario"];
                    user.Clave = (string)dr["clave"];
                    user.Habilitado = (bool)dr["habilitado"];
                    user.CambiaClave = (bool)dr["cambia_clave"];
                    user.Persona = PersonaData.GetOne((int)dr["id_persona"]);

                    usuarios.Add(user);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario user = null;

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@idUsuario", SqlConn);
                cmd.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = ID;
                
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    user = new Usuario();

                    PersonaAdapter PersonaData = new PersonaAdapter();

                    user.ID = (int)dr["id_usuario"];
                    user.NombreUsuario = (string)dr["nombre_usuario"];
                    user.Clave = (string)dr["clave"];
                    user.Habilitado = (bool)dr["habilitado"];
                    user.CambiaClave = (bool)dr["cambia_clave"];
                    user.Persona = PersonaData.GetOne((int)dr["id_persona"]);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return user;
        }

        public Usuario BuscarPorLegajo(int legajo)
        {
            Usuario user = null;

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios u INNER JOIN personas p " +
                    "ON u.id_persona=p.id_persona WHERE legajo=@legajo", SqlConn);
                cmd.Parameters.Add("@legajo", System.Data.SqlDbType.Int).Value = legajo;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    user = new Usuario();

                    PersonaAdapter PersonaData = new PersonaAdapter();

                    user.ID = (int)dr["id_usuario"];
                    user.NombreUsuario = (string)dr["nombre_usuario"];
                    user.Clave = (string)dr["clave"];
                    user.Habilitado = (bool)dr["habilitado"];
                    user.CambiaClave = (bool)dr["cambia_clave"];
                    user.Persona = PersonaData.GetOne((int)dr["id_persona"]);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return user;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE usuarios WHERE id_usuario=@idUsuario", SqlConn);
                cmd.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Usuario user)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombreUsuario, clave=@clave, habilitado=@habilitado," +
                    "cambia_clave=@cambiaClave, id_persona=@persona WHERE id_usuario=@idUsuario", SqlConn);

                cmd.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = user.ID;
                cmd.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar).Value = user.NombreUsuario;
                cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = user.Clave;
                cmd.Parameters.Add("@habilitado", System.Data.SqlDbType.Bit).Value = user.Habilitado;
                cmd.Parameters.Add("@cambiaClave", System.Data.SqlDbType.Bit).Value = user.CambiaClave;
                cmd.Parameters.Add("@persona", System.Data.SqlDbType.Int).Value = user.Persona.ID;

                cmd.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                if (Ex.Number == 2627)
                {
                    Exception ExcepcionManejada = new Exception("El usuario o la persona ya se encuentran registrados", Ex);
                    throw ExcepcionManejada;
                }
                else
                {
                    Exception ExcepcionManejada = new Exception("Error al actualizar usuario", Ex);
                    throw ExcepcionManejada;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Usuario user)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios (nombre_usuario, clave, habilitado, cambia_clave, id_persona)" +
                    "VALUES (@nombreUsuario, @clave, @habilitado, @cambiaClave, @persona) SELECT SCOPE_IDENTITY()", SqlConn);

                cmdSave.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar).Value = user.NombreUsuario;
                cmdSave.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = user.Clave;
                cmdSave.Parameters.Add("@habilitado", System.Data.SqlDbType.Bit).Value = user.Habilitado;
                cmdSave.Parameters.Add("@cambiaClave", System.Data.SqlDbType.Bit).Value = user.CambiaClave;
                cmdSave.Parameters.Add("@persona", System.Data.SqlDbType.Int).Value = user.Persona.ID;

                user.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteScalar());
            }
            catch (SqlException Ex)
            {
                if(Ex.Number == 2627)
                {
                    Exception ExcepcionManejada = new Exception("El nombre de usuario o la persona ya se ha registrado", Ex);
                    throw ExcepcionManejada;
                }
                else
                {
                    Exception ExcepcionManejada = new Exception("Error al agregar usuario", Ex);
                    throw ExcepcionManejada;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
