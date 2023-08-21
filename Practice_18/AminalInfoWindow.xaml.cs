using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Practice18
{
    /// <summary>
    /// Вспомогательное окно для ввода и редактирования информации о
    /// конкретном животном.
    /// </summary>
    public partial class AnimalInfoWindow : Window
    {
        // текущее животное, информация о котором редактируется
        public IAnimal? currentAnimal;

        public AnimalInfoWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Данный конструктор вызывается в случае редактирования животного
        /// из главного окна программы.
        /// </summary>
        /// <param name="animal"></param>
        public AnimalInfoWindow(IAnimal animal) : this()
        {
            int animalTypeId = AnimalFactory.GetAnimalTypeId(animal);
            currentAnimal = animal;
            cbAnimalType.SelectedIndex = animalTypeId;
            tbxName.Text = animal.Name;
            switch (animalTypeId)
            {
                case 1:
                    tbxInfo.Text = ((MammalAnimal)animal).SubType;
                    break;
                case 2:
                    rbIsFlying.IsChecked = ((BirdAnimal)animal).CanFly;
                    rbIsNotFlying.IsChecked = !((BirdAnimal)animal).CanFly;
                    break;
                case 3:
                    tbxInfo.Text = ((AmphibianAnimal)animal).TailLength.ToString();
                    break;
                default:
                    tbxInfo.Text = "";
                    break;
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                cbAnimalType.ItemsSource = ((MainWindow)Owner).AnimalTypes;
                if (cbAnimalType.SelectedIndex < 0)
                    cbAnimalType.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// Нажатие кнопки по умолчанию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text == string.Empty)
                tbxName.Background = Brushes.Red;
            if (tbxInfo.Text == string.Empty)
                tbxInfo.Background = Brushes.Red;
            if (cbAnimalType.SelectedIndex < 1)
                cbAnimalType.Background = Brushes.Red;
            if (cbAnimalType.SelectedIndex > 1 &&
                tbxName.Text != string.Empty &&
                cbAnimalType.SelectedIndex != 2 ?
                tbxInfo.Text != string.Empty : true)
            {
                if (currentAnimal == null) // в случае создания нового животного
                {
                    switch (cbAnimalType.SelectedIndex)
                    {
                        case 1:
                            currentAnimal = AnimalFactory.GetNewAnimal("mammal", tbxName.Text, tbxInfo.Text);
                            break;
                        case 2:
                            currentAnimal = AnimalFactory.GetNewAnimal("bird", tbxName.Text, rbIsFlying.IsChecked.ToString()!);
                            break;
                        case 3:
                            currentAnimal = AnimalFactory.GetNewAnimal("amphibian", tbxName.Text, tbxInfo.Text);
                            break;
                        default:
                            currentAnimal = AnimalFactory.GetNewAnimal("", tbxName.Text, tbxInfo.Text);
                            break;
                    }
                }
                else // в случае редактирвоания существующего животного
                {
                    currentAnimal.AnimalTypeDisplayName = AnimalFactory.GetAnimalTypeName(cbAnimalType.SelectedIndex);
                    currentAnimal.Name = tbxName.Text;
                    switch (cbAnimalType.SelectedIndex)
                    {
                        case 1:
                            ((MammalAnimal)currentAnimal).SubType = tbxInfo.Text;
                            break;
                        case 2:
                            ((BirdAnimal)currentAnimal).CanFly = rbIsFlying.IsChecked!.Value;
                            break;
                        case 3:
                            int tailL = 0;
                            int.TryParse(tbxInfo.Text, out tailL);
                            ((AmphibianAnimal)currentAnimal).TailLength = tailL;
                            break;
                        default:
                            break;
                    }
                }
                DialogResult = true;
                Close();
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxName.Text.Length > 0)
                tbxName.Background = Brushes.White;
        }

        private void tbInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxInfo.Text.Length > 0)
                tbxInfo.Background = Brushes.White;
        }

        // на случай, если нужно ограничить ввод только цифрами
        private static readonly Regex regex = new Regex("[^0-9]+");
        private void tbInfo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (cbAnimalType.SelectedIndex == 3)
                e.Handled = regex.IsMatch(e.Text);
        }

        private void cbAnimalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbAnimalType.SelectedIndex)
            {
                case 2:
                    spBird.Visibility = Visibility.Visible;
                    tbxInfo.Visibility = Visibility.Hidden;
                    break;
                default:
                    spBird.Visibility = Visibility.Hidden;
                    tbxInfo.Visibility = Visibility.Visible;
                    break;
            }
            switch (cbAnimalType.SelectedIndex)
            {
                case 1:
                    tbInfo.Text = "Подвид";
                    break;
                case 2:
                    tbInfo.Text = "Птица летающая/нелетающая";
                    break;
                case 3:
                    tbInfo.Text = "Длина хвоста";
                    break;
                default:
                    tbInfo.Text = "Информация";
                    break;
            }

        }
    }
}
