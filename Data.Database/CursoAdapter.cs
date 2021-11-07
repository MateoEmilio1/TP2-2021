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
    public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand(" " +
                    "select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                ComisionAdapter ComisionAdapter = new ComisionAdapter();
                MateriaAdapter MateriaAdapter = new MateriaAdapter();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia = MateriaAdapter.GetOne((int)drCursos["id_materia"]);
                    cur.Comision = ComisionAdapter.GetOne((int)drCursos["id_comision"]);
                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }
        public List<Curso> GetAllReporte()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand(" " +
                    "select *, nombre + ' ' + apellido as nombre_completo " +
                    "from cursos " +
                    "inner join " +
                    "(select id_curso, coalesce(count(*),0) cantidad_alumnos, convert(varchar(50),coalesce(avg(nota),0),3) nota_promedio from alumnos_inscripciones group by id_curso) a " +
                    "on cursos.id_curso = a.id_curso " +
                    "inner join docentes_cursos " +
                    "on docentes_cursos.id_curso = cursos.id_curso " +
                    "inner join personas " +
                    "on personas.id_persona = docentes_cursos.id_docente", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                ComisionAdapter ComisionAdapter = new ComisionAdapter();
                MateriaAdapter MateriaAdapter = new MateriaAdapter();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia = MateriaAdapter.GetOne((int)drCursos["id_materia"]);
                    cur.Comision = ComisionAdapter.GetOne((int)drCursos["id_comision"]);
                    cur.CantidadAlumnos = (int)drCursos["cantidad_alumnos"];
                    cur.NotaPromedio = double.Parse((string)drCursos["nota_promedio"]);
                    cur.NombreDocente = (string)drCursos["nombre_completo"];
                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public List<Curso> GetCursosDocente(int ID)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos "+
                "inner join docentes_cursos on cursos.id_curso = docentes_cursos.id_curso " +
                "where docentes_cursos.id_docente=@id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                ComisionAdapter ComisionAdapter = new ComisionAdapter();
                MateriaAdapter MateriaAdapter = new MateriaAdapter();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia = MateriaAdapter.GetOne((int)drCursos["id_materia"]);
                    cur.Comision = ComisionAdapter.GetOne((int)drCursos["id_comision"]);
                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del curso", Ex);
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
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                ComisionAdapter ComisionAdapter = new ComisionAdapter();
                MateriaAdapter MateriaAdapter = new MateriaAdapter();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia = MateriaAdapter.GetOne((int)drCursos["id_materia"]);
                    cur.Comision = ComisionAdapter.GetOne((int)drCursos["id_comision"]);

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del curso", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_curso = @id " +
                    "delete docentes_cursos where id_curso = @id " +
                    "delete cursos where id_curso=@id ", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE cursos SET id_comision=@IDComision, id_materia=@IDMateria, anio_calendario=@anio, cupo=@cupo "
                    + "WHERE id_curso=@id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdUpdate.Parameters.Add("@IDComision", SqlDbType.Int).Value = curso.Comision.ID;
                cmdUpdate.Parameters.Add("@IDMateria", SqlDbType.Int).Value = curso.Materia.ID;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into cursos(id_materia,id_comision,anio_calendario,cupo) " +
                "values(@IDMateria,@IDComision,@anio,@cupo) ", sqlConn);
                cmdInsert.Parameters.Add("@IDMateria", SqlDbType.Int).Value = curso.Materia.ID;
                cmdInsert.Parameters.Add("@IDComision", SqlDbType.Int).Value = curso.Comision.ID;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear un nuevo curso", Ex);
                
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

    }
}
