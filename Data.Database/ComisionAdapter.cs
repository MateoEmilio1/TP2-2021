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
    public class ComisionAdapter: Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from comisiones ", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Comision cur = new Comision();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.Descripcion = (string)drCursos["id_comision"];
                    cur.IDPlan = (int)drCursos["id_plan"];
                    comisiones.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision cur = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from comisiones where id_curso=@id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.Descripcion = (string)drCursos["id_comision"];                    
                    cur.IDPlan = (int)drCursos["id_plan"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del comision", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE comisiones SET id_comision=@Descripcion, anio_especialidad=@AnioEspecialidad, id_plan=@id_plan "
                    + "WHERE id_curso=@id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdUpdate.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = comision.Descripcion;
                cmdUpdate.Parameters.Add("@AnioEspecialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into comisiones(anio_especialidad,desc_comision,id_plan) " +
                "values(@AnioEspecialidad,@Descripcion,@id_plan) ", sqlConn);
                cmdInsert.Parameters.Add("@AnioEspecialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdInsert.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear un nuevo comision", Ex);
                
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }

    }
}
