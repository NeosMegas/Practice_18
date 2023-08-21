using System;

namespace Practice18
{
    /// <summary>
    /// Класс, использующий паттерн "Фабрика" для быстрого создания
    /// новых животных и получения общей информации о доступных
    /// типах животных.
    /// </summary>
    public static class AnimalFactory
    {
        static IModel? model;

        /// <summary>
        /// Обязательна инициализация, т.к. используется модель.
        /// </summary>
        /// <param name="model">Модель взаимодействия с базой данных</param>
        public static void Initialize(IModel model)
        {
            AnimalFactory.model = model;
        }

        /// <summary>
        /// Получение нового животного
        /// </summary>
        /// <param name="animalType">Тип животного</param>
        /// <param name="name">Наименование животного</param>
        /// <param name="info">Дополнительная инфорация о животном, в зависимости от типа</param>
        /// <returns>Новое животное</returns>
        /// <exception cref="Exception">Если Фабрика не инициализирована, вызовет исключение</exception>
        public static IAnimal GetNewAnimal(string animalType, string name, string info)
        {
            if (model != null)
            {
                switch (animalType)
                {
                    case "mammal": return new MammalAnimal(model.NextId, model.GetAnimalDisplayName("mammal"), name, info);
                    case "bird":
                        bool canFly;
                        if (!bool.TryParse(info, out canFly)) canFly = false;
                        return new BirdAnimal(model.NextId, model.GetAnimalDisplayName("bird"), name, canFly);
                    case "amphibian":
                        int tailLength;
                        if (!int.TryParse(info, out tailLength)) tailLength = 0;
                        return new AmphibianAnimal(model.NextId, model.GetAnimalDisplayName("amphibian"), name, tailLength);
                    default: return new UnknownAnimal(model.NextId);
                }
            }
            else throw new Exception("AnimalFactory model not initialized.");
        }

        /// <summary>
        /// Получения Id типа конкретного животного
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <returns>Id типа животного</returns>
        /// <exception cref="Exception">Если Фабрика не инициализирована, вызовет исключение</exception>
        public static int GetAnimalTypeId(IAnimal animal)
        {
            if (model != null)
                return model.GetAnimalTypeId(animal.AnimalTypeName);
            else
                throw new Exception("AnimalFactory model not initialized.");
        }

        /// <summary>
        /// Получения Id типа конкретного по наименованю типа животного
        /// </summary>
        /// <param name="animalTypeName">Наименование типа животного: mammal, bird, amphibian или unknown</param>
        /// <returns>Id типа животного</returns>
        /// <exception cref="Exception">Если Фабрика не инициализирована, вызовет исключение</exception>
        public static int GetAnimalTypeId(string animalTypeName)
        {
            if (model != null)
                return model.GetAnimalTypeId(animalTypeName);
            else
                throw new Exception("AnimalFactory model not initialized.");
        }

        /// <summary>
        /// Получения наименования типа животного по Id типа (метод, обратный предыдущему)
        /// </summary>
        /// <param name="animalTypeId">Id типа животного</param>
        /// <returns>Наиенование типа животного</returns>
        /// <exception cref="Exception">Если Фабрика не инициализирована, вызовет исключение</exception>
        public static string GetAnimalTypeName(int animalTypeId)
        {
            if (model != null)
                return model.GetAnimalTypes()[animalTypeId];
            else
                throw new Exception("AnimalFactory model not initialized.");
        }

    }
}
