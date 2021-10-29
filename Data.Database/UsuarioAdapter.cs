using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities; //Agrego el using necesario para la capa Datos
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Usuario> usuarios = new List<Usuario>();
            try
            {


                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                    usuarios.Add(usr);
                }

                //cerramos la el DataReader y la conexión a la BD
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            //devolvemos el objeto
            return usuarios;

        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            //instanciamos el objeto lista a retornar
            Usuario usr = new Usuario();
            try
            {


                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                }

                //cerramos la el DataReader y la conexión a la BD
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            //devolvemos el objeto
            return usr;

        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM usuarios WHERE id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                "WHERE id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email)" +
                "values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
                "select @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        public bool Existe(string user)
        {
            bool existe;
            try
            {
                OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from usuarios where nombre_usuario=@usuario", sqlConn);
                cmdGetOne.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar que no exista este Usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return existe;
        }


        public Usuario GetUsuarioLogin(string user, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand(
                    "SELECT * FROM usuarios "+
                    "where nombre_usuario = @user and clave = @pass", sqlConn);
                cmdUsuarios.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                cmdUsuarios.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usr;

        }
    }
}
