using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class MateriaCorrelativaAdapter: Adapter
    {
        public List<MateriaCorrelativa> GetAll()
        {
            List<MateriaCorrelativa> materiasCorrelativas = new List<MateriaCorrelativa>();
            MateriaAdapter ma = new MateriaAdapter();

            try
            {
                this.OpenConnection();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM materias_correlativas", SqlConn);

                SqlDataReader dr = sqlCommand.ExecuteReader();

                if(dr != null)
                {
                    while (dr.Read())
                    {
                        MateriaCorrelativa mc = new MateriaCorrelativa();

                        mc.ID = (int)dr["id_materia_correlativa"];
                        mc.MateriaSucesora = ma.GetOne((int)dr["id_materia_sucesora"]);
                        mc.MateriaPredecesora = ma.GetOne((int)dr["id_materia_predecesora"]);
                        mc.Condicion = (MateriaCorrelativa.Condiciones)dr["condicion"];

                        materiasCorrelativas.Add(mc);
                    }
                }

                if (dr != null) dr.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias correlativas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return materiasCorrelativas;
        }

        public MateriaCorrelativa GetOne(int ID)
        {
            MateriaAdapter mat = new MateriaAdapter();
            MateriaCorrelativa matCorr = null;

            try
            {
                this.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM materias_correlativas WHERE id_materia_correlativa=@idMateria", SqlConn);
                sqlCommand.Parameters.Add("@idMateria", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = sqlCommand.ExecuteReader();

                if(dr != null && dr.Read())
                {
                    matCorr = new MateriaCorrelativa();

                    matCorr.ID = (int)dr["id_materia_correlativa"];
                    matCorr.MateriaSucesora = mat.GetOne((int)dr["id_materia_sucesora"]);
                    matCorr.MateriaPredecesora = mat.GetOne((int)dr["id_materia_predecesora"]);
                    matCorr.Condicion = (MateriaCorrelativa.Condiciones)dr["condicion"];
                }

                if (dr != null) dr.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia correlativa", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return matCorr;
        }

        public void Update(MateriaCorrelativa mat)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUpdate = new SqlCommand("UPDATE materias_correlativas SET id_materia_sucesora=@idMatSuc, id_materia_predecesora=@idMatPred, condicion=@Condicion WHERE id_materia_correlativa=@idMateria", SqlConn);

                cmdUpdate.Parameters.Add("idMatSuc", System.Data.SqlDbType.Int).Value = mat.MateriaSucesora.ID;
                cmdUpdate.Parameters.Add("idMatPred", System.Data.SqlDbType.Int).Value = mat.MateriaPredecesora.ID;
                cmdUpdate.Parameters.Add("Condicion", System.Data.SqlDbType.Int).Value = mat.Condicion;
                cmdUpdate.Parameters.Add("idMateria", System.Data.SqlDbType.Int).Value = mat.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar materia correlativa", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE materias_correlativas WHERE id_materia_correlativa=@ID", SqlConn);

                cmdDelete.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();

            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia correlativa", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert (MateriaCorrelativa mat)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO materias_correlativas (id_materia_sucesora, id_materia_predecesora, condicion) VALUES (@idMatSuc, @idMatPre, @condicion) SELECT SCOPE_IDENTITY()", SqlConn);

                cmdInsert.Parameters.Add("@idMatSuc", System.Data.SqlDbType.Int).Value = mat.MateriaSucesora.ID;
                cmdInsert.Parameters.Add("@idMatPre", System.Data.SqlDbType.Int ).Value = mat.MateriaPredecesora.ID;
                cmdInsert.Parameters.Add("@condicion", System.Data.SqlDbType.Int).Value = mat.Condicion;

                mat.ID = Decimal.ToInt32((Decimal)cmdInsert.ExecuteScalar());
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar materia correlativa", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
