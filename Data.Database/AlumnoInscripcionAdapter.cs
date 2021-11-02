using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter: Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos_inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones ", sqlConn);
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();
                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion aluins = new AlumnoInscripcion();
                    aluins.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluins.IDAlumno = (int)drAlumnosInscripciones["id_materia"];
                    aluins.IDCurso = (int)drAlumnosInscripciones["id_comision"];
                    aluins.Condicion = (String)drAlumnosInscripciones["condicion"];
                    aluins.Nota = (int)drAlumnosInscripciones["nota"];
                    alumnos_inscripciones.Add(aluins);
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return alumnos_inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion aluins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInscripciones = cmdAlumnoInscripcion.ExecuteReader();
                if (drAlumnosInscripciones.Read())
                {
                    aluins.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluins.IDAlumno = (int)drAlumnosInscripciones["id_materia"];
                    aluins.IDCurso = (int)drAlumnosInscripciones["id_comision"];                    
                    aluins.Condicion = (String)drAlumnosInscripciones["condicion"];
                    aluins.Nota = (int)drAlumnosInscripciones["nota"];
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del aluins", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return aluins;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(AlumnoInscripcion aluins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET id_inscripcion=@id, id_alumno=@IDAlumno,id_curso = @IDCurso condicion=@condicion, nota=@nota "
                    + "WHERE id_inscripcion=@id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = aluins.ID;
                cmdUpdate.Parameters.Add("@IDCurso", SqlDbType.Int).Value = aluins.IDCurso;
                cmdUpdate.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = aluins.IDAlumno;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar).Value = aluins.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = aluins.Nota;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(AlumnoInscripcion aluins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into alumnos_inscripciones(id_inscripcion,id_alumno,id_curso,nota) " +
                "values(@IDAlumno,@IDCurso,@condicion,@nota) ", sqlConn);
                cmdInsert.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = aluins.IDAlumno;
                cmdInsert.Parameters.Add("@IDCurso", SqlDbType.Int).Value = aluins.IDCurso;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar).Value = aluins.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = aluins.Nota;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear una nueva inscripción", Ex);
                
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(AlumnoInscripcion aluins)
        {
            if (aluins.State == BusinessEntity.States.Deleted)
            {
                this.Delete(aluins.ID);
            }
            else if (aluins.State == BusinessEntity.States.New)
            {
                this.Insert(aluins);
            }
            else if (aluins.State == BusinessEntity.States.Modified)
            {
                this.Update(aluins);
            }
            aluins.State = BusinessEntity.States.Unmodified;
        }

    }
}
