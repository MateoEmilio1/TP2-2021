using Data.Database;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

public class MateriaAdapter : Adapter
{
    public List<Materia> GetAll()
    {
        List<Materia> materias = new List<Materia>();
        try
        {
            OpenConnection();
            SqlCommand cmdMaterias = new SqlCommand("select * from materias ", sqlConn);
            SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
            while (drMaterias.Read())
            {
                Materia mat = new Materia();
                mat.ID = (int)drMaterias["id_materia"];
                mat.Descripcion = (string)drMaterias["desc_materia"];
                mat.HSSemanales = (int)drMaterias["hs_semanales"];
                mat.HSTotales = (int)drMaterias["hs_totales"];
                mat.IDPlan = (int)drMaterias["id_plan"];
                materias.Add(mat);
            }
            drMaterias.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
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
        Materia mat = new Materia();
        try
        {
            this.OpenConnection();
            SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
            cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            SqlDataReader drMaterias = cmdMateria.ExecuteReader();
            if (drMaterias.Read())
            {
                mat.ID = (int)drMaterias["id_materia"];
                mat.Descripcion = (string)drMaterias["desc_materia"];
                mat.HSSemanales = (int)drMaterias["hs_semanales"];
                mat.HSTotales = (int)drMaterias["hs_totales"];
                mat.IDPlan = (int)drMaterias["id_plan"];
            }
            drMaterias.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de la materia", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
        return mat;
    }

    public void Delete(int ID)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
            cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            cmdDelete.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada =
                new Exception("Error al eliminar la materia", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
    }
    public void Update(Materia materia)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE materias SET desc_materia=@Descripcion, hs_semanales=@HSSMateria, hs_totales=@HSTotales, id_plan=@IDPlan "
                + "WHERE id_materia=@id", sqlConn);
            cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
            cmdUpdate.Parameters.Add("@Descripcion", SqlDbType.Int).Value = materia.Descripcion;
            cmdUpdate.Parameters.Add("@HSSMateria", SqlDbType.Int).Value = materia.HSSemanales;
            cmdUpdate.Parameters.Add("@HSTotales", SqlDbType.Int).Value = materia.HSTotales;
            cmdUpdate.Parameters.Add("@IDPlan", SqlDbType.Int).Value = materia.IDPlan;
            cmdUpdate.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada =
                new Exception("Error al modificar datos de la materia", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public void Insert(Materia materia)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmdInsert = new SqlCommand(
            "insert into materias(id_materia,desc_materia,hs_semanales,hs_totales,id_plan) " +
            "values(@IDMateria,@DescMateria,@HSSemanales,@HSTotales,@IDPlan) ", sqlConn);
            cmdInsert.Parameters.Add("@IDMateria", SqlDbType.Int).Value = materia.ID;
            cmdInsert.Parameters.Add("@DescMateria", SqlDbType.Int).Value = materia.Descripcion;
            cmdInsert.Parameters.Add("@HSSemanales", SqlDbType.Int).Value = materia.HSSemanales;
            cmdInsert.Parameters.Add("@HSTotales", SqlDbType.Int).Value = materia.HSTotales;
            cmdInsert.Parameters.Add("@IDPlan", SqlDbType.Int).Value = materia.IDPlan;
            cmdInsert.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada =
                new Exception("Error al crear una nueva materia", Ex);

            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public void Save(Materia materia)
    {
        if (materia.State == BusinessEntity.States.Deleted)
        {
            this.Delete(materia.ID);
        }
        else if (materia.State == BusinessEntity.States.New)
        {
            this.Insert(materia);
        }
        else if (materia.State == BusinessEntity.States.Modified)
        {
            this.Update(materia);
        }
        materia.State = BusinessEntity.States.Unmodified;
    }

}
