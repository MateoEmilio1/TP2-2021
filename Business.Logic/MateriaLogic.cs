using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter MateriaData { get; set; }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Materia GetOne(int ID)
        {

            return (MateriaData.GetOne(ID));
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
        public void Delete(int ID)
        {
            //invocar metodo delete de MateriaData
            MateriaData.Delete(ID);
        }

        public void Update(Business.Entities.Materia materia)
        {
            MateriaData.Update(materia);
        }


    }
}
