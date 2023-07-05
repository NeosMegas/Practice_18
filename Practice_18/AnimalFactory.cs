using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18
{
    public static class AnimalFactory
    {
        public static IAnimal GetAnimal(string animalType, string name, string info)
        {
            switch (animalType)
            {
                case "mammal": return new MammalAnimal(name, info);
                case "bird":
                    bool canFly;
                    if (!bool.TryParse(info, out canFly)) canFly = false;
                    return new BirdAnimal(name, canFly);
                case "amphibian":
                    int tailLength;
                    if (!int.TryParse(info, out tailLength)) tailLength = 0;
                    return new AmphibianAnimal(name, tailLength);
                default: return new UnknownAnimal();
            }
        }
    }
}
