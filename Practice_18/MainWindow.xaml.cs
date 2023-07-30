﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice_18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        Presenter presenter;
        public List<IAnimal> Animals {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            Animals = new List<IAnimal>();
            lvAnimals.ItemsSource = presenter.Animals;
        }
    }
}
