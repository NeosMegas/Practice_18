namespace Practice18
{
    /// <summary>
    /// Интерфейс описания общих данных о животном.
    /// </summary>
    public interface IAnimal
    {
        // Id животного в БД
        public int Id { get; set; }
        // Внутреннее наименование типа животного (напр., "mammal")
        public string AnimalTypeName { get; set; }
        // Отображаемое для пользователя наименование типа животного
        // (напр., "млекопитающее")
        public string AnimalTypeDisplayName { get; set; }
        // Наименование животного (напр., "собака")
        public string Name { get; set; }
        // последний Id животного в БД
        public static int lastId { get; set; }
    }
}
