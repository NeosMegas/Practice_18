using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Practice_18
{
    internal class SQLiteModel : IModel
    {
        public List<BaseAnimal> Animals { get;}

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
        public void Add(BaseAnimal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
        }

        public void Edit(BaseAnimal animal)
        {
            db.Entry(animal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(BaseAnimal animal)
        {
            db.Animals.Remove(animal);
            db.SaveChanges();
        }
        // 🤔
    }
}
*/