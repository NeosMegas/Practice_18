using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18
{
    internal class Presenter
    {
        IView view;
        IModel model;

        //AnimalsContext db = new AnimalsContext();

        //public List<IAnimal> Animals { get; set; }

        public Presenter(IView view)
        {
            /*db.Database.EnsureCreated();
            db.Animals.Load();
            Animals = db.Animals.Local.ToList();*/
            this.view = view;
            model = new SQLiteModel("animals.db");
        }

    }
}
