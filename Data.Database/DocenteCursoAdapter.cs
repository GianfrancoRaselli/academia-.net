using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace Data.Database
{
    public class DocenteCursoAdapter: Adapter
    {
        public List<Curso> GetCursos(int idDocente)
        {
            List<Curso> cursos = new List<Curso>();
            CursoAdapter ca = new CursoAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * from docentes_cursos WHERE id_docente=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int ).Value= idDocente;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Curso curso = new Curso();
                    curso = ca.GetOne((int)dr["id_curso"]);

                    cursos.Add(curso);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos del Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }
    }
}
