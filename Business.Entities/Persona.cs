using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        //private TipoPersonas _TipoPersona;
        private string _TipoPersona;
        private Plan _Plan;

        public string Apellido
        {
            get
            {
                return _Apellido;
            }
            set
            {
                _Apellido = value;
            }

        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            }

        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }

        }
        public DateTime FechaNacimiento
        {
            get
            {
                return _FechaNacimiento;
            }
            set
            {
                _FechaNacimiento = value;
            }

        }

        public int IDPlan
        {
            get
            {
                return _IDPlan;
            }
            set
            {
                _IDPlan = value;
            }

        }
        public int Legajo
        {
            get
            {
                return _Legajo;
            }
            set
            {
                _Legajo = value;
            }

        }
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }

        }
        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
            }

        }


        public Persona() //Constructor base 
        {
            this.Plan = new Plan();
        }

        public Plan Plan
        {
            get 
            { 
                return _Plan; 
            }
            set 
            { 
                _Plan = value; 
            }
        }

        public string TipoPersona
        {
            get 
            { 
                return _TipoPersona; 
            }
            set 
            { 
                _TipoPersona = value; 
            }
        }

        public string DescPlan
        {
            get { return _Plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return _Plan.DescEspecialidad; }
        }

        /*
        public TipoPersonas TipoPersona //Propiedad
        {
            get
            {
                return _TipoPersona;
            }
            set
            {
                _TipoPersona = value;
            }
        }

        public enum TipoPersonas //(puedo declararlo arriba si quiero)
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
        */
    }
}
