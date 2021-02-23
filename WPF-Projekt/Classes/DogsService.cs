using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt.Classes
{
    public class DogsService
    {
        public DogsService(DogsBaseEntities db)
        {
            Db = db;
        }


        public void Add(Dog dogs)
        {
            Db.Dogs.Add(dogs);
            Db.SaveChanges();
        }

        public void Remove(Dog dogs)
        {
            Db.Dogs.Remove(dogs);
            Db.SaveChanges();
        }
        public void Edit(Dog dogs)
        {
            var dog = Db.Dogs.FirstOrDefault(d => dogs.Id == d.Id);
            if (dog != null)
                Db.SaveChanges();
        }

        public Dog GetById(int id)
        {
            return Db.Dogs.FirstOrDefault(d => id == d.Id);
        }


        public DogsBaseEntities Db { get; }

        public List<Dog> GetList()
        {

            return Db.Dogs
                //.Include(d=>d.Owner_id)
                .ToList();
        }
    }
}
