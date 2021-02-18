using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy DogsWindow.xaml
    /// </summary>
    public partial class DogsWindow : Window
    {
        public DogsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void PreviousDog(object sender, RoutedEventArgs e)
        {

        }

        private void NextDog(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {

        }

        private void DogProfileData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
