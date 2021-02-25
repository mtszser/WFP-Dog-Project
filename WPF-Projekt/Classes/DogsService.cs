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

        public void AddOwner(DogsOwner dogsOwner)
        {
            Db.DogsOwners.Add(dogsOwner);
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

        public DogsOwner GetOwnerById(int id)
        {
            return Db.DogsOwners.FirstOrDefault(o => id == o.Owner_id);
        }


        public DogsBaseEntities Db { get; }

        public List<Dog> GetDogList()
        {

            return Db.Dogs
                //.Include(d=>d.Owner_id)
                .ToList();
        }

        public List<DogsOwner> GetOwnerList()
        {
            return Db.DogsOwners.ToList();
            
        }

    }
}
