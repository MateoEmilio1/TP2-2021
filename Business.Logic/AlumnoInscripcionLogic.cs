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

        public void Save(AlumnoInscripcion aluins)
        {
            AluInsData.Save(aluins);
        }
        public void Delete(int ID)
        {
            //invocar metodo delete de Cursodata
            AluInsData.Delete(ID);
        }

        

        


    }
}
