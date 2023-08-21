using System.Collections.Generic;

namespace Practice18
{
    /// <summary>
    /// Интерфейс модели взаимодействия с базой данных
    /// </summary>
    public interface IModel
    {
        int LastId { get; }
        int NextId { get; }
        List<IAnimal> Animals { get; }
        string GetAnimalDisplayName(string animalTypeName);
        int GetAnimalTypeId(string animalTypeName);
        List<string> GetAnimalTypes();
        void Add(IAnimal animal);
        void Edit(IAnimal animal, int listIndex);
        void Remove(IAnimal animal, int listIndex);
    }
}
