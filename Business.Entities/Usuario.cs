using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {

        //propfull (doble tab) = variable + propiedad

        private string _nombreUsuario;
        private string _clave;
        private string _nombre;
        private string _apellido;
        private string _email;
        private bool _habilitado;
        private int _idpersona;

        public string NombreUsuario //Propiedad
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }

        }
        public string Clave //Propiedad
        {
            get
            {
                return _clave;
            }
            set
            {
                _clave = value;
            }

        }
        public string Nombre //Propiedad
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }

        }
        public string Apellido //Propiedad
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }

        }
        public string EMail //Propiedad
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }

        }
        public bool Habilitado //Propiedad
        {
            get
            {
                return _habilitado;
            }
            set
            {
                _habilitado = value;
            }

        }

                

        public int IDPersona
        {
            get { return _idpersona; }
            set { _idpersona= value; }
        }




    }
}
