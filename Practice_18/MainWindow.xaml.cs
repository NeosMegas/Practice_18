using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;

namespace Practice18
{
    /// <summary>
    /// Окно, представлющее реализацию вида
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        readonly Presenter presenter;
        // вспомогательное окно для ввода и редактирования данных о
        // конкретном животном
        AnimalInfoWindow? infoWindow;
        // список типов животных
        public List<string> AnimalTypes { get; } = new();

        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            lvAnimals.ItemsSource = presenter.Animals;
            AnimalTypes = presenter.AnimalTypes;
        }

        /// <summary>
        /// Добавление животного
        /// </summary>
        public void AddAnimal()
        {
            infoWindow = new()
            {
                Owner = this
            };
            infoWindow.ShowDialog();
            if (infoWindow.DialogResult is not null && infoWindow.DialogResult == true)
            {
                presenter.AddAnimal(infoWindow.currentAnimal!);
            }
        }
        
        /// <summary>
        /// Редактирование животного
        /// </summary>
        public void EditAnimal()
        {
            if (lvAnimals.SelectedIndex < 0) return;
            infoWindow = new(presenter.Animals[lvAnimals.SelectedIndex])
            {
                Owner = this
            };
            infoWindow.ShowDialog();
            if (infoWindow.DialogResult is not null && infoWindow.DialogResult == true)
            {
                presenter.EditAnimal(infoWindow.currentAnimal!, lvAnimals.SelectedIndex);
            }

        }

        /// <summary>
        /// Удаление животного
        /// </summary>
        public void RemoveAnimal()
        {
            if (lvAnimals.SelectedIndex < 0) return;
            if (MessageBox.Show($"Вы действительно хотите удалить {presenter.Animals[lvAnimals.SelectedIndex]}?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                presenter.RemoveAnimal(presenter.Animals[lvAnimals.SelectedIndex], lvAnimals.SelectedIndex);
        }
        public void UpdateAnimalList()
        {
            lvAnimals.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAnimal();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditAnimal();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveAnimal();
        }

        /// <summary>
        /// Экспорт БД животных в различные форматы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = "Animals";
            fd.DefaultExt = ".txt";
            fd.Filter = "Текстовые документы (*.txt)|*.txt|Данные, разделённые запятой (*.csv)|*.csv|Данные XML (*.xml)|*.xml";
            if (fd.ShowDialog() == true)
            {
                AnimalExporter animalExporter = new AnimalExporter(new AnimalExportTXT(fd.FileName), presenter.Animals);
                switch (fd.FilterIndex)
                {
                    case 2:
                        animalExporter.Mode = new AnimalExportCSV(fd.FileName);
                        break;
                    case 3:
                        animalExporter.Mode = new AnimalExportXML(fd.FileName);
                        break;
                }
                animalExporter.Export();
            }
        }
    }
}
