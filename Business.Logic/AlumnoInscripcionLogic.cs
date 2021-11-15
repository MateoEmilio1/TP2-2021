using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter AluInsData { get; set; }

        public AlumnoInscripcionLogic()
        {
            AluInsData = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return (AluInsData.GetOne(ID));

            
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AluInsData.GetAll(); 
        }
        public List<AlumnoInscripcion> GetAllUsuarioActual(int IDActual)
        {
            return AluInsData.GetAllUsuarioActual(IDActual);
        }

        public void Save(AlumnoInscripcion aluins)
        {
            AluInsData.Save(aluins);
        }
        public void Delete(int ID)
        {
            //invocar metodo delete de Cursodata
            AluInsData.Delete(ID);
        }

        public List<AlumnoInscripcion> GetAlumnosCurso(int id_curso)
        {
            return AluInsData.GetAlumnosCurso(id_curso);
        }





    }
}
