namespace Practice18;

/// <summary>
/// Класс животного птица
/// </summary>
public partial class BirdAnimal : IAnimal
{
    public int Id { get; set; }
    public string AnimalTypeName { get; set; } = "bird";
    public string AnimalTypeDisplayName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    // свойство, определяющее, является ли птица летающей или
    // нет (уникальное свойство класса)
    public bool CanFly { get; set; } = true;
    public BirdAnimal(int id, string animalTypeDisplayName, string name, bool canFly)
    {
        Id = id;
        AnimalTypeDisplayName = animalTypeDisplayName;
        Name = name;
        CanFly = canFly;
    }

    public override string ToString()
    {
        return "Птица" + (CanFly ? " летающая" : " нелетающая") + ": " + Name;
    }

}
