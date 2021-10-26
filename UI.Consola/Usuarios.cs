using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _usuario;

        public Usuarios()
        {

            //UsuarioLogic _usuario = new UsuarioLogic();
            _usuario = new UsuarioLogic();
        }


        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }

        public void Menu()
        {
            bool band = true;

            //Al elegir una opción, cada uno debe invocar al método correspondiente
            //Luego de realizar una operación el menú debe volver a mostrarse
            do
            {
                Console.Clear();

                Console.WriteLine("Elija una opcion: ");
                Console.WriteLine("1- Listado General ");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("0- Salir");

                ConsoleKeyInfo opcion = Console.ReadKey(); //para no tener que apretar enter al seleccionar la opcion

                switch (opcion.Key)
                {

                    case ConsoleKey.D1:

                        ListadoGeneral();

                        break;

                    case ConsoleKey.D2:

                        Consultar();

                        break;

                    case ConsoleKey.D3:

                        Agregar();

                        break;

                    case ConsoleKey.D4:

                        Modificar();

                        break;

                    case ConsoleKey.D5:

                        Eliminar();

                        break;

                    case ConsoleKey.D0:
                        band = false;
                        break;

                }

            } while (band == true);
        }//Fin metodo Menu

        public void ListadoGeneral()
        {
            Console.Clear();
            /*recorrer la lista
            mostrando los datos de cada usuario invocando al método MostrarDatos: */

            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);

            }
        }

        public void MostrarDatos(Usuario usr)
        {
            if(usr != null)
            {
                Console.WriteLine("Usuario: {0}", usr.ID);
                Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
                Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
                Console.WriteLine("\t\tNombre de Usuario: {0} ", usr.NombreUsuario);
                Console.WriteLine("\t\tClave:{0} ", usr.Clave);
                Console.WriteLine("\t\tEmail: {0} ", usr.EMail);
                Console.WriteLine("\t\tHabilitado: {0} ", usr.Habilitado);
                // \t dentro de un string representa un TAB
                Console.ReadKey();

            }else
            {
                Console.WriteLine("Usuario no encontrado");
            }
            

        }

        //METODO CONSULTAR
        /*From inside a try block, initialize only variables that are declared therein. 
         * Otherwise, an exception can occur before the execution of the block is completed.*/

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID)); 
            }
            
            catch(IndexOutOfRangeException )
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch   (FormatException )
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero"); 

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);

            }
            catch   (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        
        public void Agregar()
        {
            Console.Clear();
            Usuario usuario = new Usuario();

            Console.Write("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.EMail = Console.ReadLine();
            Console.Write("Ingrese habilitacion de usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}");

        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.EMail = Console.ReadLine();
                Console.Write("Ingrese habilitacion de usuario (1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero"); 

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }




        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }


    }
}
