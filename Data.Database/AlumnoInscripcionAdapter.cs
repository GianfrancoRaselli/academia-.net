using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public int GetCantidadAlumnosInscriptos(int ID)
        {
            int cantAlumnosInscriptos = 0;

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM cursos c INNER JOIN" +
                    " alumnos_inscripciones ai on ai.id_curso=c.id_curso WHERE c.id_curso=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                cantAlumnosInscriptos = (int)cmd.ExecuteScalar();
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

            return cantAlumnosInscriptos;
        }

        public List<AlumnoInscripcion> GetInscripcionesDelAlumno(Persona per)
        {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            CursoAdapter CursoData = new CursoAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno=@alumno", SqlConn);
                cmd.Parameters.Add("@alumno", System.Data.SqlDbType.Int).Value = per.ID;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();

                    alumnoInscripcion.ID = (int)dr["id_inscripcion"];
                    alumnoInscripcion.Condicion = (AlumnoInscripcion.Condiciones)dr["condicion"];
                    try
                    {
                        int nota = (int)dr["nota"];
                        alumnoInscripcion.Nota = nota;
                    }
                    catch(Exception) { }
                    alumnoInscripcion.Curso = CursoData.GetOne((int)dr["id_curso"]);

                    alumnoInscripciones.Add(alumnoInscripcion);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return alumnoInscripciones;
        }

        public List<AlumnoInscripcion> GetInscripcionesDelCurso(Curso cur)
        {
            List<AlumnoInscripcion> cursoInscripciones = new List<AlumnoInscripcion>();
            PersonaAdapter PersonaData = new PersonaAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso=@curso", SqlConn);
                cmd.Parameters.Add("@curso", System.Data.SqlDbType.Int).Value = cur.ID;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();

                    alumnoInscripcion.ID = (int)dr["id_inscripcion"];
                    alumnoInscripcion.Condicion = (AlumnoInscripcion.Condiciones)dr["condicion"];
                    try
                    {
                        int nota = (int)dr["nota"];
                        alumnoInscripcion.Nota = nota;
                    }
                    catch (Exception) { }
                    alumnoInscripcion.Alumno = PersonaData.GetOne((int)dr["id_alumno"]);
                    alumnoInscripcion.LegajoAlumno = alumnoInscripcion.Alumno.Legajo;
                    alumnoInscripcion.NombreAlumno = alumnoInscripcion.Alumno.Nombre;
                    alumnoInscripcion.ApellidoAlumno = alumnoInscripcion.Alumno.Apellido;

                    cursoInscripciones.Add(alumnoInscripcion);
                }

                if(dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursoInscripciones;
        }

        public void Insert(int idPersona, int idCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion) " +
                    "VALUES (@idAlumno, @idCurso, @condicion)", SqlConn);

                cmd.Parameters.Add("@idAlumno", System.Data.SqlDbType.Int).Value = idPersona;
                cmd.Parameters.Add("@idCurso", System.Data.SqlDbType.Int).Value = idCurso;
                cmd.Parameters.Add("@condicion", System.Data.SqlDbType.Int).Value = AlumnoInscripcion.Condiciones.Inscripto;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void ActualizarNota(int idInscripcion, int nota)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE alumnos_inscripciones SET nota=@nota, condicion=@condicion " +
                    "WHERE id_inscripcion=@id", SqlConn);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idInscripcion;
                cmd.Parameters.Add("@nota", System.Data.SqlDbType.Int).Value = nota;
                if(nota <= 3)
                {
                    cmd.Parameters.Add("@condicion", System.Data.SqlDbType.Int).Value = AlumnoInscripcion.Condiciones.Libre;
                }
                else if(nota <= 5)
                {
                    cmd.Parameters.Add("@condicion", System.Data.SqlDbType.Int).Value = AlumnoInscripcion.Condiciones.Regular;
                }
                else if(nota <= 10)
                {
                    cmd.Parameters.Add("@condicion", System.Data.SqlDbType.Int).Value = AlumnoInscripcion.Condiciones.Aprobada;
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar nota", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int idPersona, int idCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE alumnos_inscripciones WHERE " +
                    "id_alumno=@idAlumno and id_curso=@idCurso", SqlConn);

                cmd.Parameters.Add("@idAlumno", System.Data.SqlDbType.Int).Value = idPersona;
                cmd.Parameters.Add("@idCurso", System.Data.SqlDbType.Int).Value = idCurso;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}