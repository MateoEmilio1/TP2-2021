using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Curso GetOne(int ID)
        {


            return (CursoData.GetOne(ID));
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll(); 
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
        public void Delete(int ID)
        {
            //invocar metodo delete de Cursodata
            CursoData.Delete(ID);
        }

        public bool ExisteComision(int ID)
        {
            return CursoData.ExisteComision(ID);
        }

        public bool ExisteMateria(int ID)
        {
            return CursoData.ExisteMateria(ID);
        }




    }
}
