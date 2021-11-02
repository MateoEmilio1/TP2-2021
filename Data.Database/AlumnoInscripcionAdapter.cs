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
                    new Exception("Error al recuperar datos del aluinsso", Ex);
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
        public void Update(AlumnoInscripcion aluinsso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET id_comision=@IDCurso, id_materia=@IDAlumno, condicion=@condicion, nota=@nota "
                    + "WHERE id_inscripcion=@id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = aluinsso.ID;
                cmdUpdate.Parameters.Add("@IDCurso", SqlDbType.Int).Value = aluinsso.IDCurso;
                cmdUpdate.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = aluinsso.IDAlumno;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar).Value = aluinsso.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = aluinsso.Nota;
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

        public void Insert(AlumnoInscripcion aluinsso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into alumnos_inscripciones(id_materia,id_comision,condicion,nota) " +
                "values(@IDAlumno,@IDCurso,@condicion,@nota) ", sqlConn);
                cmdInsert.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = aluinsso.IDAlumno;
                cmdInsert.Parameters.Add("@IDCurso", SqlDbType.Int).Value = aluinsso.IDCurso;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar).Value = aluinsso.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = aluinsso.Nota;
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


        public void Save(AlumnoInscripcion aluinsso)
        {
            if (aluinsso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(aluinsso.ID);
            }
            else if (aluinsso.State == BusinessEntity.States.New)
            {
                this.Insert(aluinsso);
            }
            else if (aluinsso.State == BusinessEntity.States.Modified)
            {
                this.Update(aluinsso);
            }
            aluinsso.State = BusinessEntity.States.Unmodified;
        }

    }
}
