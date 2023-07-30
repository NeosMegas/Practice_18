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

        public List<IAnimal> Animals { get; set; }

        public Presenter(IView view)
        {
            model = new SQLiteModel();
            Animals = model.Animals;
            this.view = view;
        }

        public void GetData()
        {
            // model.GetData()
            // result = model.Result()
            // view.Result = result
        }

        public void AddAminal(IAnimal animal)
        {

        }

        public void RemoveAminal(IAnimal animal)
        {

        }

        public void EditAminal(IAnimal animal)
        {

        }
    }
}
