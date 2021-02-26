using System;
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
    /// Logika interakcji dla klasy JurorWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void AddDog_Click(object sender, RoutedEventArgs e)
        {
            AddDog addDog = new AddDog();
            addDog.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            Highscore highscore = new Highscore();
            highscore.ShowDialog();
        }

        private void DogProfile_Click(object sender, RoutedEventArgs e)
        {
            DogsWindow dogsWindow = new DogsWindow();
            dogsWindow.ShowDialog();
            
        }

        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {
            AddOwner addowner = new AddOwner();
            addowner.Show();
        }
    }
}
