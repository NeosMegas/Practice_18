namespace Practice18;

/// <summary>
/// Класс млекопитающего животного
/// </summary>
public partial class MammalAnimal : IAnimal
{
    public int Id { get; set; }
    public string AnimalTypeName { get; set; } = "mammal";
    public string AnimalTypeDisplayName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    // подтип млекопитающего (уникальное свойство класса)
    public string SubType { get; set; } = string.Empty;

    public MammalAnimal(int id, string animalTypeDisplayName, string name, string subType)
    {
        Id = id;
        AnimalTypeDisplayName = animalTypeDisplayName;
        Name = name;
        SubType = subType;
    }

    public override string ToString()
    {
        return "Млекопитающее: " + Name + ", подвид: " + SubType;
    }
}
