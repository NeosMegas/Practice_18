using System.Collections.Generic;
using System.Xml.Linq;

namespace Practice18
{
    /// <summary>
    /// Класс, реализующий экспорт БД в файл XML
    /// </summary>
    internal class AnimalExportXML : IAnimalExportMode
    {
        public string FileName { get; set; }

        public void Export(List<IAnimal> animals)
        {
            XElement xmlAnimals = new XElement("ЖИВОТНЫЕ");
            XElement xmlAnimal;
            XAttribute xmlAnimalType;
            XAttribute xmlAnimalName;
            XAttribute xmlAnimalInfo;

            foreach (IAnimal animal in animals)
            {
                xmlAnimal = new XElement("Животное");
                xmlAnimalType = new XAttribute("Тип", animal.AnimalTypeDisplayName);
                xmlAnimalName = new XAttribute("Наименование", animal.Name);
                xmlAnimal.Add(xmlAnimalType);
                xmlAnimal.Add(xmlAnimalName);
                switch (animal.AnimalTypeName)
                {
                    case "mammal":
                        xmlAnimalInfo = new XAttribute("Подтип", ((MammalAnimal)animal).SubType);
                        break;
                    case "bird":
                        xmlAnimalInfo = new XAttribute("Летающая", ((BirdAnimal)animal).CanFly ? "летающая" : "нелетающая");
                        break;
                    case "amphibian":
                        xmlAnimalInfo = new XAttribute("Хвост", ((AmphibianAnimal)animal).TailLength > 0 ? ((AmphibianAnimal)animal).TailLength.ToString() : "бесхвостая");
                        break;
                    default:
                        xmlAnimalInfo = new XAttribute("Информация", "неизвестное животное");
                        break;
                }
                xmlAnimal.Add(xmlAnimalInfo);
                xmlAnimals.Add(xmlAnimal);
            }
            xmlAnimals.Save(FileName);
        }

        public AnimalExportXML(string fileName)
        {
            FileName = fileName;
        }
    }
}
