namespace Practice18
{
    /// <summary>
    /// Интерфейс вида, отображающего базу данных животных
    /// </summary>
    internal interface IView
    {
        void AddAnimal();
        void EditAnimal();
        void RemoveAnimal();
        void UpdateAnimalList();
    }
}
