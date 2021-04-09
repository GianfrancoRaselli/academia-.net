using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comisiones", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)dr["id_comision"];
                    com.Descripcion = (string)dr["desc_comision"];
                    com.AnioEspecialidad = (int)dr["anio_especialidad"];
                    com.Plan = PlanData.GetOne((int)dr["id_plan"]);
                    com.DescPlan = com.Plan.Descripcion + " - " + com.Plan.Especialidad.Descripcion;

                    comisiones.Add(com);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = null;
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@idComision", SqlConn);
                cmd.Parameters.Add("@idComision", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    com = new Comision();

                    com.ID = (int)dr["id_comision"];
                    com.Descripcion = (string)dr["desc_comision"];
                    com.AnioEspecialidad = (int)dr["anio_especialidad"];
                    com.Plan = PlanData.GetOne((int)dr["id_plan"]);
                    com.DescPlan = com.Plan.Descripcion;
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete comisiones WHERE id_comision=@idComision", SqlConn);
                cmdDelete.Parameters.Add("@idComision", System.Data.SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Comision com)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @descComision, anio_especialidad= @anioEspecialidad, id_plan = @idPlan WHERE id_comision = @idComision", SqlConn);

                cmdSave.Parameters.Add("@idComision", System.Data.SqlDbType.Int).Value = com.ID;
                cmdSave.Parameters.Add("@descComision", System.Data.SqlDbType.VarChar).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anioEspecialidad", System.Data.SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@idPlan", System.Data.SqlDbType.Int).Value = com.Plan.ID;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision com)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan ) VALUES (@descComision, @anioEspecialidad, @idPlan) SELECT SCOPE_IDENTITY()", SqlConn);

                cmdInsert.Parameters.Add("@descComision", System.Data.SqlDbType.VarChar).Value = com.Descripcion;
                cmdInsert.Parameters.Add("@anioEspecialidad", System.Data.SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdInsert.Parameters.Add("@idPlan", System.Data.SqlDbType.Int).Value = com.Plan.ID;
                com.ID = Decimal.ToInt32((Decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}