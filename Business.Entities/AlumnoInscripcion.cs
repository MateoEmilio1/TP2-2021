using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _Condicion;
        private int _Nota;

        public string Condicion
        {
            get
            {
                return _Condicion;
            }
            set
            {
                _Condicion = value;
            }
        }
        

        public int Nota
        {
            get
            {
                return _Nota;
            }
            set
            {
                _Nota = value;
            }
        }

        public Persona Persona { get; set; }

        public string Nombre
        {
            get { return Persona.Nombre; }
            set { Persona.Nombre = value; }
        }
        public string Apellido
        {
            get { return Persona.Apellido; }
            set { Persona.Apellido = value; }
        }
        public int Legajo
        {
            get { return Persona.Legajo; }
            set { Persona.Legajo = value; }
        }
        private int myVar;

        


        public Curso Curso { get; set; }
    }
}
