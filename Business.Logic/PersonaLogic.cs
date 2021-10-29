using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        private PersonaAdapter _persona;
        public PersonaLogic() //Constructor base
        {

            //UsuarioAdapter _usuario = new UsuarioAdapter();
            _persona = new PersonaAdapter();

        }

        //LAB03, PUNTO 3- INCISO 4 (seguir con inciso 8 metodo GetOne)
        public PersonaAdapter PersonaData //Propiedad PersonaData del tipo Data.Database.PersonaAdapter
        {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
            }
        }

        public Personas GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public bool Existe(int leg)
        {
            return _persona.ExistePersona(leg);
        }

        public List<Personas> GetAll()
        {
            return PersonaData.GetAll(0);
        }

        public List<Personas> GetAlumnos()
        {
            return PersonaData.GetAll(1);
        }

        public List<Personas> GetDocentes()
        {
            return PersonaData.GetAll(2);
        }

        public void Save(Personas persona)
        {
            PersonaData.Save(persona);

        }
        public void Delete(int ID)
        {
            //invocar metodo delete de usuariodata
            PersonaData.Delete(ID);

        }

        

        public bool ExistePerson(int leg)
        {
            return PersonaData.ExistePersona(leg);
        }
    }
}
