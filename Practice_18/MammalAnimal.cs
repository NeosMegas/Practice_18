using System;
using System.Collections.Generic;

namespace Practice_18;

public partial class MammalAnimal : IAnimal
{
    public long Id { get; set; }
    public string AnimalType { get; set; } = "mammal";
    public string Name { get; set; } = string.Empty;
    public string SubType { get; set; } = string.Empty;
    public MammalAnimal(string name, string subType)
    {
        Name = name;
        SubType = subType;
    }
}
