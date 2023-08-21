using System.Collections.Generic;
using System.IO;

namespace Practice18
{
    /// <summary>
    /// Класс, реализующий экспорт БД в текстовый файл
    /// </summary>
    internal class AnimalExportTXT : IAnimalExportMode
    {
        public string FileName { get; set; }
        protected string delimeter = "\t";

        public void Export(List<IAnimal> animals)
        {
            using (StreamWriter writer = new StreamWriter(FileName, false))
            {
                string s = "";
                foreach (IAnimal animal in animals)
                {
                    s = animal.Id.ToString() + delimeter
                        + animal.AnimalTypeDisplayName.ToString() + delimeter
                        + animal.Name + delimeter;
                    switch (animal.AnimalTypeName)
                    {
                        case "mammal":
                            s += "подтип: " + ((MammalAnimal)animal).SubType;
                            break;
                        case "bird":
                            s += ((BirdAnimal)animal).CanFly ? "летающая" : "нелетающая";
                            break;
                        case "amphibian":
                            s += ((AmphibianAnimal)animal).TailLength>0 ? "длина хвоста: " + ((AmphibianAnimal)animal).TailLength.ToString() : "бесхвостая";
                            break;
                        default:
                            break;
                    }
                    writer.WriteLine(s);
                }
            }
        }

        public AnimalExportTXT(string fileName)
        {
            FileName = fileName;
        }
    }
}
