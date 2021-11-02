using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Comision GetOne(int ID)
        {


            return ComisionData.GetOne(ID);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll(); 
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }
        public void Delete(int ID)
        {
            //invocar metodo delete de Cursodata
            ComisionData.Delete(ID);
        }

        

        


    }
}
