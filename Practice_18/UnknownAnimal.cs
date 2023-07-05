using System;
using System.Collections.Generic;

namespace Practice_18;

public partial class UnknownAnimal : IAnimal
{
    public long Id { get; set; }

    public string AnimalType { get; set; } = "unknown";

    public string Name { get; set; } = "Неизвестное жывтоне";
}
