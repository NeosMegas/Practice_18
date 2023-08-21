using System.Collections.Generic;

namespace Practice18
{
    /// <summary>
    /// Интерфейс, описывающий функционал экспорта БД в файл
    /// </summary>
    internal interface IAnimalExportMode
    {
        string FileName { get; set; }
        void Export(List<IAnimal> animals);
    }
}
