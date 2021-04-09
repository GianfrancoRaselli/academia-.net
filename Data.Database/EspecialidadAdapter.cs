using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Especialidad esp = new Especialidad();

                    esp.ID = (int)dr["id_especialidad"];
                    esp.Descripcion = (string)dr["desc_especialidad"];

                    especialidades.Add(esp);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = null;

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@idEspecialidad", SqlConn);
                cmd.Parameters.Add("@idEspecialidad", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    esp = new Especialidad();

                    esp.ID = (int)dr["id_especialidad"];
                    esp.Descripcion = (string)dr["desc_especialidad"];
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE especialidades WHERE id_especialidad=@idEspecialidad", SqlConn);
                cmd.Parameters.Add("@idEspecialidad", System.Data.SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE especialidades SET desc_especialidad=@descEspecialidad WHERE id_especialidad=@idEspecialidad", SqlConn);

                cmd.Parameters.Add("@idEspecialidad", System.Data.SqlDbType.Int).Value = esp.ID;
                cmd.Parameters.Add("@descEspecialidad", System.Data.SqlDbType.VarChar).Value = esp.Descripcion;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO especialidades (desc_especialidad) VALUES (@descEspecialidad) SELECT SCOPE_IDENTITY()", SqlConn);
                cmd.Parameters.Add("@descEspecialidad", System.Data.SqlDbType.VarChar).Value = esp.Descripcion;

                esp.ID = Decimal.ToInt32((Decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
