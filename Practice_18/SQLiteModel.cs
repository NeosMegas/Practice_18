using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Practice18
{
    /// <summary>
    /// Модель взаимодействия с базой данный SQLite
    /// </summary>
    internal class SQLiteModel : IModel
    {
        int _lastId = -1;
        // последний Id в БД
        public int LastId { get { return _lastId; } }
        // новый Id для БД
        public int NextId { get { return _lastId + 1; } }
        // текущий загруженный из БД список животных
        public List<IAnimal> Animals { get;} = new List<IAnimal>();
        // строка подключения к БД
        string connectionString = "Data Source=animals.db";
        // словарь отображаемых наименований типов животных в зависимости
        // от встроенных наименований
        Dictionary<string, string> animalDisplayNames = new();
        // словарь Id типов животных в зависимости от встроенных наименований
        Dictionary<string, int> animalTypeIds = new();

        public SQLiteModel(string dbName)
        {
            connectionString = "Data Source=" + dbName;
            GetDataFromDB();
        }

        public SQLiteModel()
        {
            GetDataFromDB();
        }

        /// <summary>
        /// Загрузка данных из базы данных
        /// </summary>
        void GetDataFromDB()
        {
            LoadAnimalTypeNames();
            using SqliteConnection connection = new(new SqliteConnectionStringBuilder(connectionString).ConnectionString);
            connection.Open();
            string sql = "SELECT animals.Id, animalTypes.Name as \"AnimalType\", animalTypes.DisplayName as \"AnimalTypeName\", animals.Name, animals.Info FROM animals, animalTypes WHERE animals.AnimalType = animalTypes.Id";
            SqliteCommand command = new(sql, connection);
            SqliteDataReader reader = command.ExecuteReader();
            IAnimal animal;
            while (reader.Read())
            {
                string animalType = reader["AnimalType"].ToString() ?? "unknown";
                int animalId = Convert.ToInt32(reader["Id"]);
                if (animalId > _lastId) _lastId = animalId;
                animal = animalType switch
                {
                    "mammal" => new MammalAnimal(animalId, animalDisplayNames[reader["AnimalType"].ToString() ?? ""], reader["Name"].ToString() ?? "", reader["Info"].ToString() ?? ""),
                    "bird" => new BirdAnimal(animalId, animalDisplayNames[reader["AnimalType"].ToString() ?? ""], reader["Name"].ToString() ?? "", (reader["Info"].ToString() ?? "false").ToLower() == "true"),
                    "amphibian" => new AmphibianAnimal(animalId, animalDisplayNames[reader["AnimalType"].ToString() ?? ""], reader["Name"].ToString() ?? "", Convert.ToInt32(reader["Info"])),
                    _ => new UnknownAnimal(animalId),
                };
                Animals.Add(animal);
            }
        }

        /// <summary>
        /// Загрузка наименований типов животных из вспомогательной таблицы базы данных.
        /// </summary>
        void LoadAnimalTypeNames()
        {
            using SqliteConnection connection = new(new SqliteConnectionStringBuilder(connectionString).ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM animalTypes";
            SqliteCommand command = new(sql, connection);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                animalDisplayNames.Add(reader["Name"].ToString() ?? "", reader["DisplayName"].ToString() ?? "");
                animalTypeIds.Add(reader["Name"].ToString() ?? "", Convert.ToInt32(reader["Id"]));
            }
        }

        /// <summary>
        /// Получение отображаемого наименования типа животного в зависимости от встроенного наименования типа животного.
        /// </summary>
        /// <param name="animalTypeName">Встроенное наименование типа животного: mammal, bird, amphibian</param>
        /// <returns>Отображаемое наименование типа животного</returns>
        public string GetAnimalDisplayName(string animalTypeName)
        {
            return animalDisplayNames[animalTypeName];
        }

        /// <summary>
        /// Получение Id типа животного по встроенному наименованию типа.
        /// </summary>
        /// <param name="animalTypeName">Встроенное наименование типа животного: mammal, bird, amphibian</param>
        /// <returns>Id типа животного</returns>
        public int GetAnimalTypeId(string animalTypeName)
        {
            return animalTypeIds[animalTypeName];
        }

        /// <summary>
        /// Получение списка всех типов животных, доступных в базе данных.
        /// </summary>
        /// <returns>Список типов животных в виде строк.</returns>
        public List<string> GetAnimalTypes()
        {
            return animalDisplayNames.Values.ToList();
        }

        /// <summary>
        /// Добавление животного в базу данных.
        /// </summary>
        /// <param name="animal">Животное</param>
        public void Add(IAnimal animal)
        {
            string sql = string.Empty;
            switch (animal.AnimalTypeName)
            {
                case "mammal":
                    sql = $"INSERT INTO\r\nanimals (AnimalType, Name, Info)\r\nVALUES\r\n({animalTypeIds[animal.AnimalTypeName]}, '{animal.Name}', '{((MammalAnimal)animal).SubType}');";
                    break;
                case "bird":
                    sql = $"INSERT INTO\r\nanimals (AnimalType, Name, Info)\r\nVALUES\r\n({animalTypeIds[animal.AnimalTypeName]}, '{animal.Name}', '{((BirdAnimal)animal).CanFly}');";
                    break;
                case "amphibian":
                    sql = $"INSERT INTO\r\nanimals (AnimalType, Name, Info)\r\nVALUES\r\n( {animalTypeIds[animal.AnimalTypeName]} , '{animal.Name}', '{((AmphibianAnimal)animal).TailLength}');";
                    break;
                default:
                    break;
            }
            using SqliteConnection connection = new(new SqliteConnectionStringBuilder(connectionString).ConnectionString);
            connection.Open();
            SqliteCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            Animals.Add(animal);
        }

        /// <summary>
        /// Редактирование животного в базе данных.
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <param name="listIndex">Id животного в текущем списке животных</param>
        public void Edit(IAnimal animal, int listIndex)
        {
            string sql = string.Empty;
            switch (animal.AnimalTypeName)
            {
                case "mammal":
                    sql = $"UPDATE animals SET AnimalType={animalTypeIds[animal.AnimalTypeName]}, Name='{animal.Name}', Info='{((MammalAnimal)animal).SubType}' WHERE Id={animal.Id};";
                    break;
                case "bird":
                    sql = $"UPDATE animals SET AnimalType={animalTypeIds[animal.AnimalTypeName]}, Name='{animal.Name}', Info='{((BirdAnimal)animal).CanFly}' WHERE Id={animal.Id};";
                    break;
                case "amphibian":
                    sql = $"UPDATE animals SET AnimalType={animalTypeIds[animal.AnimalTypeName]}, Name='{animal.Name}', Info='{((AmphibianAnimal)animal).TailLength}' WHERE Id={animal.Id};";
                    break;
                default:
                    break;
            }
            using SqliteConnection connection = new(new SqliteConnectionStringBuilder(connectionString).ConnectionString);
            connection.Open();
            SqliteCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            Animals[listIndex] = animal;
        }

        /// <summary>
        /// Удаление животного из базы данных.
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <param name="listIndex">Id животного в текущем списке животных.</param>
        public void Remove(IAnimal animal, int listIndex)
        {
            string sql = string.Empty;
            sql = $"DELETE FROM animals WHERE Id={animal.Id};";
            using SqliteConnection connection = new(new SqliteConnectionStringBuilder(connectionString).ConnectionString);
            connection.Open();
            SqliteCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            Animals.RemoveAt(listIndex);
        }
    }
}
