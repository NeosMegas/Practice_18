using System;
using System.Collections.Generic;

namespace Practice_18;

public partial class BirdAnimal : IAnimal
{
    public long Id { get; set; }
    public string AnimalType { get; set; } = "bird";
    public string Name { get; set; } = string.Empty;
    public bool CanFly { get; set; } = true;
    public BirdAnimal(string name, bool canFly)
    {
        Name = name;
        CanFly = canFly;
    }
}
