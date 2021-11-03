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
        private bool _habilitado;

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


        public Persona Persona { get; set; }

        

    }
}
