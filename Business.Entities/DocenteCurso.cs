using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class DocenteCurso:BusinessEntity
    {

        private int _IDCurso;
        private int _IDDocente;
        private TiposCargos _Cargo;

        public DocenteCurso()
        {
            this.Cargo = TiposCargos.New;
        }
        public enum TiposCargos
        {
            Deleted, 
            New,  
            Modified, 
            Unmodified
        }
        
        public TiposCargos Cargo //Propiedad
        {
            get
            {
                return _Cargo;
            }
            set
            {
                _Cargo = value;
            }
        }

        public int IDCurso
        {
            get
            {
                return _IDCurso;

            }
            set
            {
                _IDCurso = value;
            }

        }

        public int IDDocente
        {
            get
            {
                return _IDDocente;

            }
            set
            {
                _IDDocente = value;
            }

        }

    }
}
