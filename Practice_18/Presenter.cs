using System.Collections.Generic;

namespace Practice18
{
    /// <summary>
    /// Класс, осуществляющий взаимодействие между моделью
    /// и видом в паттерне MVP
    /// </summary>
    internal class Presenter
    {
        // вид
        readonly IView view;
        // модель
        readonly IModel model;
        // список животных
        public List<IAnimal> Animals;
        // список типов животных
        public List<string> AnimalTypes {
            get
            {
                return model.GetAnimalTypes();
            }
        }

        public Presenter(IView view)
        {
            model = new SQLiteModel();
            Animals = model.Animals;
            this.view = view;
            AnimalFactory.Initialize(model);
        }

        /// <summary>
        /// Добавление животного в БД
        /// </summary>
        /// <param name="animal">Животное</param>
        public void AddAnimal(IAnimal animal)
        {
            model.Add(animal);
            view.UpdateAnimalList();
        }

        /// <summary>
        /// Редактирование животного в БД
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <param name="listIndex">Id животного в текущем загруженном списке</param>
        public void EditAnimal(IAnimal animal, int listIndex)
        {
            model.Edit(animal, listIndex);
            view.UpdateAnimalList();
        }

        /// <summary>
        /// Удаление животного из БД
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <param name="listIndex">Id животного в текущем загруженном списке</param>
        public void RemoveAnimal(IAnimal animal, int listIndex)
        {
            model.Remove(animal, listIndex);
            view.UpdateAnimalList();
        }
    }
}
