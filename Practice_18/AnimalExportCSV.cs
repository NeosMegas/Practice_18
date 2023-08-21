namespace Practice18
{
    /// <summary>
    /// Класс, реализующий экспорт БД в файл данных, разделённых запятыми
    /// </summary>
    internal class AnimalExportCSV : AnimalExportTXT, IAnimalExportMode
    {
        public AnimalExportCSV(string fileName) : base(fileName)
        {
            delimeter = ";";
        }
    }
}
