using System.Collections.Generic;

namespace Practice18
{
    /// <summary>
    /// Класс, реализующий функционал экспорта БД в файл.
    /// Использует внедрение зависимостей.
    /// </summary>
    internal class AnimalExporter
    {
        // интерфейс, описывающий режим экспорта (формат файла)
        public IAnimalExportMode Mode { get; set; }
        public List<IAnimal> Animals { get; set; }

        public AnimalExporter(IAnimalExportMode mode, List<IAnimal> animals)
        {
            Mode = mode;
            Animals = animals;
        }

        public void Export()
        {
            Mode.Export(Animals);
        }

    }
}
