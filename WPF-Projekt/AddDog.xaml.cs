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
using System.Windows.Shapes;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for AddDog1.xaml
    /// </summary>
    public partial class AddDog : Window
    {
        public AddDog()
        {
            InitializeComponent();
        }

        private void AddNewDog(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}