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


        //Estos métodos son necesarios para ser utilizados en el reporte de cursos.
        public string MateriaDescripcion
        {
            get { return Materia.Descripcion; }
        }

        public string ComisionDescripcion
        {
            get { return Comision.Descripcion; }
        }

        public int CantidadAlumnos { get; set; }

        public string NombreDocente { get; set; }

        public double NotaPromedio { get; set; }
    }
}
