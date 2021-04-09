using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            MateriaAdapter MateriaData = new MateriaAdapter();
            ComisionAdapter ComisionData = new ComisionAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)dr["id_curso"];
                    cur.AnioCalendario = (int)dr["anio_calendario"];
                    cur.Cupos = (int)dr["cupo"];
                    cur.Materia = MateriaData.GetOne((int)dr["id_materia"]);
                    cur.Comision = ComisionData.GetOne((int)dr["id_comision"]);
                    cur.DescComision = cur.Comision.Descripcion;
                    cur.Comenzado = (bool)dr["comenzado"];
                    cur.TipoCuatrimestre = (Curso.TiposCuatrimestre)dr["cuatrimestre"];

                    cursos.Add(cur);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public List<Curso> GetCursosDelDocente(Persona per)
        {
            List<Curso> cursos = new List<Curso>();
            MateriaAdapter MateriaData = new MateriaAdapter();
            ComisionAdapter ComisionData = new ComisionAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT c.* FROM cursos c INNER JOIN docentes_cursos dc " +
                    "ON dc.id_curso=c.id_curso WHERE dc.id_docente=@docente", SqlConn);
                cmd.Parameters.Add("@docente", System.Data.SqlDbType.Int).Value = per.ID;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)dr["id_curso"];
                    cur.AnioCalendario = (int)dr["anio_calendario"];
                    cur.Cupos = (int)dr["cupo"];
                    cur.Materia = MateriaData.GetOne((int)dr["id_materia"]);
                    cur.Comision = ComisionData.GetOne((int)dr["id_comision"]);
                    cur.DescComision = cur.Comision.Descripcion;
                    cur.Comenzado = (bool)dr["comenzado"];
                    cur.TipoCuatrimestre = (Curso.TiposCuatrimestre)dr["cuatrimestre"];

                    cursos.Add(cur);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public List<Curso> GetCursosDeLaMateriaDisponibles(Materia materia)
        {
            List<Curso> cursos = new List<Curso>();
            MateriaAdapter MateriaData = new MateriaAdapter();
            ComisionAdapter ComisionData = new ComisionAdapter();
            AlumnoInscripcionAdapter AlumnosInscripcionesData = new AlumnoInscripcionAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos WHERE id_materia=@materia AND " +
                    "comenzado=0", SqlConn);
                cmd.Parameters.Add("@materia", System.Data.SqlDbType.Int).Value = materia.ID;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)dr["id_curso"];
                    cur.AnioCalendario = (int)dr["anio_calendario"];
                    cur.Cupos = (int)dr["cupo"];
                    cur.Materia = MateriaData.GetOne((int)dr["id_materia"]);
                    cur.Comision = ComisionData.GetOne((int)dr["id_comision"]);
                    cur.DescComision = cur.Comision.Descripcion;
                    cur.Comenzado = (bool)dr["comenzado"];
                    cur.TipoCuatrimestre = (Curso.TiposCuatrimestre)dr["cuatrimestre"];
                    cur.CuposDisponibles= cur.Cupos-AlumnosInscripcionesData.GetCantidadAlumnosInscriptos(cur.ID);

                    cursos.Add(cur);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = null;
            MateriaAdapter MateriaData = new MateriaAdapter();
            ComisionAdapter ComisionData = new ComisionAdapter();
            AlumnoInscripcionAdapter AlumnosInscripcionesData = new AlumnoInscripcionAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    cur = new Curso();

                    cur.ID = (int)dr["id_curso"];
                    cur.AnioCalendario = (int)dr["anio_calendario"];
                    cur.Cupos = (int)dr["cupo"];
                    cur.Materia = MateriaData.GetOne((int)dr["id_materia"]);
                    cur.Comision = ComisionData.GetOne((int)dr["id_comision"]);
                    cur.DescComision = cur.Comision.Descripcion;
                    cur.Comenzado = (bool)dr["comenzado"];
                    cur.TipoCuatrimestre = (Curso.TiposCuatrimestre)dr["cuatrimestre"];
                    cur.CuposDisponibles = cur.Cupos - AlumnosInscripcionesData.GetCantidadAlumnosInscriptos(cur.ID);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Curso curs)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE cursos SET anio_calendario=@anio_calendario, cupo=@cupos," +
                    "id_materia=@id_materia, id_comision=@id_comision, comenzado=@comenzado, cuatrimestre=@cuatrimestre " +
                    "WHERE id_curso=@id", SqlConn);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = curs.ID;
                cmd.Parameters.Add("@anio_calendario", System.Data.SqlDbType.Int).Value = curs.AnioCalendario;
                cmd.Parameters.Add("@cupos", System.Data.SqlDbType.Int).Value = curs.Cupos;
                cmd.Parameters.Add("@id_materia", System.Data.SqlDbType.Int).Value = curs.Materia.ID;
                cmd.Parameters.Add("@id_comision", System.Data.SqlDbType.Int).Value = curs.Comision.ID;
                cmd.Parameters.Add("@comenzado", System.Data.SqlDbType.Bit).Value = curs.Comenzado;
                cmd.Parameters.Add("@cuatrimestre", System.Data.SqlDbType.Int).Value = curs.TipoCuatrimestre;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curs)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO cursos (anio_calendario, cupo, id_materia, id_comision, comenzado, cuatrimestre)" +
                    "VALUES (@anio_calendario, @cupos, @id_materia, @id_comision, @comenzado, @cuatrimestre) SELECT SCOPE_IDENTITY()", SqlConn);

                cmd.Parameters.Add("@anio_calendario", System.Data.SqlDbType.Int).Value = curs.AnioCalendario;
                cmd.Parameters.Add("@cupos", System.Data.SqlDbType.Int).Value = curs.Cupos;
                cmd.Parameters.Add("@id_materia", System.Data.SqlDbType.Int).Value = curs.Materia.ID;
                cmd.Parameters.Add("@id_comision", System.Data.SqlDbType.Int).Value = curs.Comision.ID;
                cmd.Parameters.Add("@comenzado", System.Data.SqlDbType.Bit).Value = curs.Comenzado;
                cmd.Parameters.Add("@cuatrimestre", System.Data.SqlDbType.Int).Value = curs.TipoCuatrimestre;

                curs.ID = Decimal.ToInt32((Decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}