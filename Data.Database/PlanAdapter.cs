using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            EspecialidadAdapter EspecialidadData = new EspecialidadAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM planes", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)dr["id_plan"];
                    plan.Descripcion = (string)dr["desc_plan"];
                    plan.Especialidad = EspecialidadData.GetOne((int)dr["id_especialidad"]);

                    planes.Add(plan);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = null;
            EspecialidadAdapter EspecialidadData = new EspecialidadAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    plan = new Plan();

                    plan.ID = (int)dr["id_plan"];
                    plan.Descripcion = (string)dr["desc_plan"];
                    plan.Especialidad = EspecialidadData.GetOne((int)dr["id_especialidad"]);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return plan;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE planes WHERE id_plan=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE planes SET desc_plan=@desc, id_especialidad=@esp " +
                    "WHERE id_plan=@id", SqlConn);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = plan.ID;
                cmd.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = plan.Descripcion;
                cmd.Parameters.Add("@esp", System.Data.SqlDbType.Int).Value = plan.Especialidad.ID;


                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO planes (desc_plan, id_especialidad) " +
                    "VALUES (@desc, @esp) SELECT SCOPE_IDENTITY()", SqlConn);

                cmd.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = plan.Descripcion;
                cmd.Parameters.Add("@esp", System.Data.SqlDbType.Int).Value = plan.Especialidad.ID;

                plan.ID = Decimal.ToInt32((Decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}