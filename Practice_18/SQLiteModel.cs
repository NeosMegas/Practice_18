using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18
{
    internal class SQLiteModel : IModel
    {
        public List<IAnimal> Animals { get;}

        AnimalsContext db;
        public SQLiteModel(string dbName)
        {
            db = new AnimalsContext(dbName);
            Animals = db.Animals.ToList();
        }

        public SQLiteModel()
        {
            db = new AnimalsContext();
            Animals = db.Animals.ToList();
        }

        // это тут или в Presenter?🤔
        public void Add(IAnimal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
        }

        public void Edit(IAnimal animal)
        {
            db.Entry(animal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(IAnimal animal)
        {
            db.Animals.Remove(animal);
            db.SaveChanges();
        }
        // 🤔
    }
}
