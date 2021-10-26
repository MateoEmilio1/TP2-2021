using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace Business.Entities
{
    public class BusinessEntity
    {
        /*Esta clase contendrá los elementos básicos que compartirán las entidades de
        nuestro sistema y luego heredarán de ella.  
         */
        //DECLARACION DE VARIABLES
        private int _ID;
        private States _State;

        public BusinessEntity() //Constructor base por default
        {
            this.State = States.New;
        }

        public int ID //Propiedad
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }

        }
        public States State //Propiedad
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
        
        public enum States //(puedo declararlo arriba si quiero)
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
