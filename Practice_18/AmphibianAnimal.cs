using System;
using System.Collections.Generic;

namespace Practice_18;

public partial class AmphibianAnimal : IAnimal
{
    public long Id { get; set; }
    public string AnimalType { get; set; } = "amphibian";
    public string Name { get; set; } = string.Empty;
    public int TailLength { get; set; } = 0;
    public AmphibianAnimal(string name, int tailLength)
    {
        Name = name;
        TailLength = tailLength;
    }
}
