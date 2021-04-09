using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", SqlConn);
                SqlDataReader dr = cmdMaterias.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)dr["id_materia"];
                    mat.Descripcion = (string)dr["desc_materia"];
                    mat.HsSemanales = (int)dr["hs_semanales"];
                    mat.HsTotales = (int)dr["hs_totales"];
                    mat.Plan = PlanData.GetOne((int)dr["id_plan"]);
                    mat.DescPlan = mat.Plan.Descripcion + " - " + mat.Plan.Especialidad.Descripcion;

                    materias.Add(mat);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<Materia> GetMateriasDelPlan(Plan plan)
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_plan=@plan " +
                    "ORDER BY desc_materia DESC", SqlConn);
                cmdMaterias.Parameters.Add("@plan", System.Data.SqlDbType.Int).Value = plan.ID;

                SqlDataReader dr = cmdMaterias.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)dr["id_materia"];
                    mat.Descripcion = (string)dr["desc_materia"];
                    mat.HsSemanales = (int)dr["hs_semanales"];
                    mat.HsTotales = (int)dr["hs_totales"];
                    mat.Plan = plan;
                    mat.DescPlan = mat.Plan.Descripcion;

                    materias.Add(mat);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = null;
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("SELECT * FROM materias WHERE id_materia=@idMateria", SqlConn);
                cmdMateria.Parameters.Add("@idMateria", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmdMateria.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    mat = new Materia();

                    mat.ID = (int)dr["id_materia"];
                    mat.Descripcion = (string)dr["desc_materia"];
                    mat.HsSemanales = (int)dr["hs_semanales"];
                    mat.HsTotales = (int)dr["hs_totales"];
                    mat.Plan = PlanData.GetOne((int)dr["id_plan"]);
                    mat.DescPlan = mat.Plan.Descripcion;
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mat;
        }

        public Materia BuscarMateriaConCorrelativas(int ID)
        {
            Materia mat = null;
            PlanAdapter PlanData = new PlanAdapter();
            MateriaAdapter MateriaData = new MateriaAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("SELECT * FROM materias WHERE id_materia=@idMateria", SqlConn);
                cmdMateria.Parameters.Add("@idMateria", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmdMateria.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    mat = new Materia();

                    mat.ID = (int)dr["id_materia"];
                    mat.Descripcion = (string)dr["desc_materia"];
                    mat.HsSemanales = (int)dr["hs_semanales"];
                    mat.HsTotales = (int)dr["hs_totales"];
                    mat.Plan = PlanData.GetOne((int)dr["id_plan"]);
                    mat.MateriasCorrelativas = MateriaData.BuscarMateriasCorrelativas(mat);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mat;
        }

        public List<MateriaCorrelativa> BuscarMateriasCorrelativas(Materia materiaSucesora)
        {
            List<MateriaCorrelativa> materias = new List<MateriaCorrelativa>();
            MateriaAdapter MateriaData = new MateriaAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias_correlativas " +
                    "WHERE id_materia_sucesora=@materiaSucesora", SqlConn);
                cmdMaterias.Parameters.Add("@materiaSucesora", System.Data.SqlDbType.Int).Value = materiaSucesora.ID;

                SqlDataReader dr = cmdMaterias.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    MateriaCorrelativa mat = new MateriaCorrelativa();
                    mat.ID = (int)dr["id_materia_correlativa"];
                    mat.MateriaPredecesora = MateriaData.GetOne((int)dr["id_materia_predecesora"]);
                    mat.Condicion = (MateriaCorrelativa.Condiciones)dr["condicion"];

                    materias.Add(mat);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return materias;
        }

        public List<Materia> BuscarMateriasCorrelativasDeLaMateria(Materia materiaSucesora)
        {
            List<Materia> materiasCorrelativas = new List<Materia>();
            MateriaAdapter MateriaData = new MateriaAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT id_materia_predecesora FROM materias_correlativas " +
                    "WHERE id_materia_sucesora=@materiaSucesora", SqlConn);
                cmdMaterias.Parameters.Add("@materiaSucesora", System.Data.SqlDbType.Int).Value = materiaSucesora.ID;

                SqlDataReader dr = cmdMaterias.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Materia mat = new Materia();
                    mat = MateriaData.GetOne((int)dr["id_materia_predecesora"]);

                    materiasCorrelativas.Add(mat);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return materiasCorrelativas;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia=@idMateria", SqlConn);
                cmdDelete.Parameters.Add("@idMateria", System.Data.SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @descMateria, hs_semanales = @hsSemanales, hs_totales = @hsTotales, id_plan = @idPlan WHERE id_materia = @idMateria", SqlConn);

                cmdSave.Parameters.Add("@idMateria", System.Data.SqlDbType.Int).Value = mat.ID;
                cmdSave.Parameters.Add("@descMateria", System.Data.SqlDbType.VarChar).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hsSemanales", System.Data.SqlDbType.Int).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@hsTotales", System.Data.SqlDbType.Int).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@idPlan", System.Data.SqlDbType.Int).Value = mat.Plan.ID;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) VALUES (@descMateria, @hsSemanales, @hsTotales, @idPlan)SELECT SCOPE_IDENTITY()", SqlConn);

                cmdInsert.Parameters.Add("@descMateria", System.Data.SqlDbType.VarChar).Value = mat.Descripcion;
                cmdInsert.Parameters.Add("@hsSemanales", System.Data.SqlDbType.Int).Value = mat.HsSemanales;
                cmdInsert.Parameters.Add("@hsTotales", System.Data.SqlDbType.Int).Value = mat.HsTotales;
                cmdInsert.Parameters.Add("@idPlan", System.Data.SqlDbType.Int).Value = mat.Plan.ID;
                mat.ID = Decimal.ToInt32((Decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}