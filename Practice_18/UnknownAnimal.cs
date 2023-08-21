namespace Practice18;

/// <summary>
/// Класс, описывающий данные неизвестного животного,
/// тип которого отсутствует в БД.
/// </summary>
public partial class UnknownAnimal : IAnimal
{
    public int Id { get; set; }

    public string AnimalTypeName { get; set; } = "unknown";
    public string AnimalTypeDisplayName { get; set; } = "неизвестное";
    public string Name { get; set; } = "Неизвестное жывтоне";

    public UnknownAnimal(int id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return Name;
    }

}
