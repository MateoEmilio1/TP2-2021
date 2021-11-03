using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;

        public int AnioCalendario
        {
            get
            {
                return _AnioCalendario;
            }
            set
            {
                _AnioCalendario = value;
            }
        }
        public int Cupo
        {
            get
            {
                return _Cupo;
            }
            set
            {
                _Cupo = value;
            }
        }
        
        

        public Materia Materia { get; set; }

        public Comision Comision { get; set; }





    }
}
