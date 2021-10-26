using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario: BusinessEntity
    {
        //variables
        private int _idUsuario;
        private int _idModulo;
        private bool _permiteAlta;
        private bool _permiteBaja;
        private bool _permiteModificacion;
        private bool _permiteConsulta;

        //Propiedades
        public int IdUsuario //Propiedad
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }

        }
        public int IdModulo //Propiedad
        {
            get
            {
                return _idModulo;
            }
            set
            {
                _idModulo = value;
            }

        }

        public bool PermiteAlta //Propiedad
        {
            get
            {
                return _permiteAlta;
            }
            set
            {
                _permiteAlta = value;
            }

        }
        public bool PermiteBaja //Propiedad
        {
            get
            {
                return _permiteBaja;
            }
            set
            {
                _permiteBaja = value;
            }

        }
        public bool PermiteModificacion //Propiedad
        {
            get
            {
                return _permiteModificacion;
            }
            set
            {
                _permiteModificacion = value;
            }

        }
        public bool PermiteConsulta //Propiedad
        {
            get
            {
                return _permiteConsulta;
            }
            set
            {
                _permiteConsulta = value;
            }

        }









    }
}
