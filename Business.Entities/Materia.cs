using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;
        private int _HSSEmanales;
        private int _HSTotales;
        private int _IDPlan;

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }


        }
        public int HSSemanales
        {
            get
            {
                return _HSSEmanales;
            }
            set
            {
                _HSSEmanales = value;
            }


        }
        public int HSTotales
        {
            get
            {
                return _HSTotales;
            }
            set
            {
                _HSTotales = value;
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

        public Persona Persona { get; set; }

        public Curso Curso { get; set; }



    }
}
