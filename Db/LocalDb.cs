using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Db
{
    public class LocalDb
    {
        public LocalDb()
        {
            Init();
        }
        private List<Persons> Persons;
        private void Init()
        {
            Persons = new List<Persons>();
            for (int i = 0; i < 30; i++)
            {
                Persons.Add(new Persons()
                {
                    ID = i+1,
                    Name =$"sample{i+1}"
                });
            }
        }
        public List<Persons> GetPersons() 
        {
            return Persons;
        }
        public void AddPerson( Persons per)
        { 
            Persons.Add(per);
        }
        public void DelPerson( int id ) 
        {
            var model=Persons.FirstOrDefault(t=>t.ID==id);
            if (model != null ) 
            {
                Persons.Remove(model);
            }
        }
        public List<Persons> GetPersonsByName(string name)
        {
            return Persons.Where(t=>t.Name.Contains(name)).ToList();
        }

        public Persons GetPersonsByID(int id)
        {
            var model= Persons.FirstOrDefault(t => t.ID == id);
            if (model != null)
            {
                return new Persons()
                {
                    ID = model.ID,
                    Name=model.Name,
                };
            }
            return null;
        }
    }
}
