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

        // Metoda dodaje obiekt psa w tabeli DOG
        public void Add(Dog dogs)
        {
            Db.Dogs.Add(dogs);
            Db.SaveChanges();
        }

        // Metoda dodająca obiekt Owner w tabeli DogsOwner
        public void AddOwner(DogsOwner dogsOwner)
        {
            Db.DogsOwners.Add(dogsOwner);
            Db.SaveChanges();
        }
        // Metoda usuwa obiekt dogs z tabeli Dog
        public void Remove(Dog dogs)
        {
            Db.Dogs.Remove(dogs);
            Db.SaveChanges();
        }
        // Metoda, która pobiera obiekt dog za pomocą jego Id i porównuje z obiektem, który jest tworzony
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
        //Pobiera liste Dog 
        public List<Dog> GetDogList()
        {

            return Db.Dogs
                //.Include(d=>d.Owner_id)
                .ToList();
        }
        //Pobiera tabele Owner do listy
        public List<DogsOwner> GetOwnerList()
        {
            return Db.DogsOwners.ToList();
            
        }
        // Pobiera tabele Score to listy
        public List<Score> GetScoreList()
        {
            return Db.Scores.ToList();
        }
        // Pobiera tabele Highscore do listy - nieskończona do końca
        public List<Highscore> GetHighscoreList()
        {
            return Db.Highscores.ToList();
        }
    }
}
