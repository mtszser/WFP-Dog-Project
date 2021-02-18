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

        public void Add(Dogs dogs)
        {
            Db.Dogs.Add(dogs);
            Db.SaveChanges();
        }
        public void Remove(Dogs dogs)
        {
            Db.Dogs.Remove(dogs);
            Db.SaveChanges();
        }
        public void Edit(Dogs dogs)
        {
            var dog = Db.Dogs.FirstOrDefault(d => dogs.Dog_id == d.Dog_id);
            if (dog != null)
            Db.SaveChanges();
        }

        public Dogs GetById(int id)
        {
            return Db.Dogs.FirstOrDefault(d => id == d.Dog_id);
        }


        public DogsBaseEntities Db { get; }

        public List<Dogs> GetList()
        {
            return Db.Dogs
                //.Include(d=>d.Owner)
                .ToList();
        }
    }
}
