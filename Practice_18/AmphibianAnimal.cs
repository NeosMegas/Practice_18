namespace Practice18;

/// <summary>
/// Класс животного амфибии
/// </summary>
public partial class AmphibianAnimal : IAnimal
{
    public int Id { get; set; }
    public string AnimalTypeName { get; set; } = "amphibian";
    public string AnimalTypeDisplayName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    // длина хвоста амфибии, если 0 - бесхвостая (уникальное свойство класса)
    public int TailLength { get; set; } = 0;
    public AmphibianAnimal(int id, string animalTypeDisplayName, string name, int tailLength)
    {
        Id = id;
        AnimalTypeDisplayName = animalTypeDisplayName;
        Name = name;
        TailLength = tailLength;
    }

    public override string ToString()
    {
        return "Амфибия"+ (TailLength > 0 ? ", длина хвоста: " + TailLength : " бесхвостая") + ": " + Name;
    }

}
