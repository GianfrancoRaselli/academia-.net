using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM personas", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Persona pers = new Persona();

                    pers.ID = (int)dr["id_persona"];
                    pers.Nombre = (string)dr["nombre"];
                    pers.Apellido = (string)dr["apellido"];
                    pers.Direccion = (string)dr["direccion"];
                    pers.Email = (string)dr["email"];
                    pers.Telefono = (string)dr["telefono"];
                    pers.Legajo = (int)dr["legajo"];
                    pers.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    pers.TipoPersona = (Persona.TiposPersona)dr["tipo_persona"];
                    pers.Plan = PlanData.GetOne((int)dr["id_plan"]);

                    personas.Add(pers);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public List<Persona> GetAlumnos()
        {
            List<Persona> personas = new List<Persona>();
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM personas WHERE tipo_persona=@tipoPersona", SqlConn);
                cmd.Parameters.Add("@tipoPersona", System.Data.SqlDbType.Int).Value = Persona.TiposPersona.Alumno;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr != null && dr.Read())
                {
                    Persona pers = new Persona();

                    pers.ID = (int)dr["id_persona"];
                    pers.Nombre = (string)dr["nombre"];
                    pers.Apellido = (string)dr["apellido"];
                    pers.Direccion = (string)dr["direccion"];
                    pers.Email = (string)dr["email"];
                    pers.Telefono = (string)dr["telefono"];
                    pers.Legajo = (int)dr["legajo"];
                    pers.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    pers.TipoPersona = (Persona.TiposPersona)dr["tipo_persona"];
                    pers.Plan = PlanData.GetOne((int)dr["id_plan"]);

                    personas.Add(pers);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public List<Persona> GetPersonasDisponibles()
        {
            
            List<Persona> personas = new List<Persona>();
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT per.* FROM personas per LEFT JOIN usuarios usu ON per.id_persona = usu.id_persona WHERE usu.id_usuario is null", SqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr != null && dr.Read())
                {
                    Persona pers = new Persona();

                    pers.ID = (int)dr["id_persona"];
                    pers.Nombre = (string)dr["nombre"];
                    pers.Apellido = (string)dr["apellido"];
                    pers.Direccion = (string)dr["direccion"];
                    pers.Email = (string)dr["email"];
                    pers.Telefono = (string)dr["telefono"];
                    pers.Legajo = (int)dr["legajo"];
                    pers.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    pers.TipoPersona = (Persona.TiposPersona)dr["tipo_persona"];
                    pers.Plan = PlanData.GetOne((int)dr["id_plan"]);

                    personas.Add(pers);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas sin usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona pers = null;
            PlanAdapter PlanData = new PlanAdapter();

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM personas WHERE id_persona=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.Read())
                {
                    pers = new Persona();

                    pers.ID = (int)dr["id_persona"];
                    pers.Nombre = (string)dr["nombre"];
                    pers.Apellido = (string)dr["apellido"];
                    pers.Direccion = (string)dr["direccion"];
                    pers.Email = (string)dr["email"];
                    pers.Telefono = (string)dr["telefono"];
                    pers.Legajo = (int)dr["legajo"];
                    pers.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    pers.TipoPersona = (Persona.TiposPersona)dr["tipo_persona"];
                    pers.Plan = PlanData.GetOne((int)dr["id_plan"]);
                }

                if (dr != null) dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return pers;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE personas WHERE id_persona=@id", SqlConn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Persona pers)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion," +
                    "fecha_nac=@fecha_nac, email=@email, telefono=@telefono, tipo_persona=@tipoPersona," +
                    "id_plan=@plan WHERE id_persona=@id", SqlConn);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = pers.ID;
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = pers.Nombre;
                cmd.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = pers.Apellido;
                cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = pers.Direccion;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = pers.Email;
                cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = pers.Telefono;
                cmd.Parameters.Add("@fecha_nac", System.Data.SqlDbType.DateTime).Value = pers.FechaNacimiento;
                cmd.Parameters.Add("@tipoPersona", System.Data.SqlDbType.Int).Value = pers.TipoPersona;
                cmd.Parameters.Add("@plan", System.Data.SqlDbType.VarChar).Value = pers.Plan.ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Persona pers)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, tipo_persona, id_plan)" +
                    "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @tipoPersona, @plan) SELECT SCOPE_IDENTITY()", SqlConn);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = pers.ID;
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = pers.Nombre;
                cmd.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = pers.Apellido;
                cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = pers.Direccion;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = pers.Email;
                cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = pers.Telefono;
                cmd.Parameters.Add("@fecha_nac", System.Data.SqlDbType.DateTime).Value = pers.FechaNacimiento;
                cmd.Parameters.Add("@tipoPersona", System.Data.SqlDbType.Int).Value = pers.TipoPersona;
                cmd.Parameters.Add("@plan", System.Data.SqlDbType.VarChar).Value = pers.Plan.ID;

                pers.ID = Decimal.ToInt32((Decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}